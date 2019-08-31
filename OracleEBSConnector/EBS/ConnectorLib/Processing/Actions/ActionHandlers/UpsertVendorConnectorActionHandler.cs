using log4net;
using ConnectorLib.API;
using ConnectorLib.Processing.Actions.ConnectorActions;

namespace ConnectorLib.Processing.Actions.ActionHandlers
{
    class UpsertVendorConnectorActionHandler : IConnectorActionHandler<UpsertVendorConnectorAction>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpsertVendorConnectorActionHandler));
        public void Handle(UpsertVendorConnectorAction action)
        {
            //Vendor upsert code
            try
            {
                using (var api = new ConnectorApi(action.source))
                {
                    Log.Info("Update vendor");
                    api.UpdateVendor(action.payload.vendor);
                    Log.Info($"Successfully Updated Vendor From MT: {action.payload.vendor.name}");          
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
