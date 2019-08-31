using log4net;
using ConnectorLib.API;
using ConnectorLib.Processing.Actions.ConnectorActions;

namespace ConnectorLib.Processing.Actions.ActionHandlers
{
    public class UpsertInvoiceConnectorActionHandler : IConnectorActionHandler<UpsertInvoiceConnectorAction>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpsertInvoiceConnectorActionHandler));

        public void Handle(UpsertInvoiceConnectorAction action)
        {
            //invoice upsert code 
            
        }
    }
}
