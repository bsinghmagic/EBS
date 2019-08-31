using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using ConnectorLib.Processing.Actions.ConnectorActions;

namespace ConnectorLib.Processing.Actions.ActionHandlers.Factory
{
    public class ConnectorActionHandlerFactory
  {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConnectorActionHandlerFactory));
        private static readonly Dictionary<Type, object> HandlersCache = new Dictionary<Type, object>();

        /// <summary>
        /// Create Action handler by action type. 
        /// Uses dynamic as result because generic interface IConnectorActionHandler uses contravariant type and cannot cast to generic by base type 
        /// </summary>
        public static dynamic CreateHandler(string actionType)
        {
            Log.DebugFormat("Creating IConnectorActionHandler for received ConnectorAction ...");

            var actionHandlerType = typeof(IConnectorActionHandler<>);
            var classType = ConnectorAction.GetActionClassType(actionType);

            if (HandlersCache.ContainsKey(classType))
            {
                return HandlersCache[classType];
            }

      var loadedAssemblies = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                          where
                            assembly.ManifestModule.Name != "<In Memory Module>"
                            && !assembly.FullName.StartsWith("System")
                            && !assembly.FullName.StartsWith("Microsoft")
                            && assembly.Location.IndexOf("App_Web") == -1
                            && assembly.Location.IndexOf("App_global") == -1
                            && assembly.FullName.IndexOf("CppCodeProvider") == -1
                            && assembly.FullName.IndexOf("WebMatrix") == -1
                            && assembly.FullName.IndexOf("SMDiagnostics") == -1
                            && assembly.FullName.IndexOf("EBS.") == -1
                            && assembly.FullName.IndexOf("Connector") >=0 
                            && !String.IsNullOrEmpty(assembly.Location)
                          select assembly).ToList();




            var actionHandlerTypes = loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => Any(type, actionHandlerType, classType)).ToArray();

            if (actionHandlerTypes.Length != 1)
                throw new Exception($"Not found or more than one action handlers implementations for action type: {actionType}");
            var handler = Activator.CreateInstance(actionHandlerTypes[0]);
            HandlersCache.Add(classType, handler);
            return handler;
        }

        /// <summary>
        /// Any of three types comparer
        /// </summary>
        private static bool Any(Type type, Type actionHandlerType, Type actionType)
        {
            var implementActionHandlers = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == actionHandlerType);
            return implementActionHandlers.Any(@interface => @interface.GenericTypeArguments.Length == 1 && @interface.GenericTypeArguments[0] == actionType);
        }
    }

}