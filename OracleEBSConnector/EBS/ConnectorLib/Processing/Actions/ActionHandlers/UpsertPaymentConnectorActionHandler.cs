using log4net;
using ConnectorLib.API;
using ConnectorLib.Processing.Actions.ConnectorActions;

namespace ConnectorLib.Processing.Actions.ActionHandlers
{
    class UpsertPaymentConnectorActionHandler : IConnectorActionHandler<UpsertPaymentConnectorAction>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpsertPaymentConnectorActionHandler));

        public void Handle(UpsertPaymentConnectorAction action)
        {
            //Payment upsert code
        }
    }
}
    