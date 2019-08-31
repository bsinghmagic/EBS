using log4net;
using ConnectorLib.API;
using ConnectorLib.Processing.Actions.ConnectorActions;

namespace ConnectorLib.Processing.Actions.ActionHandlers
{
    class UpsertPurchaseOrderConnectorActionHandler : IConnectorActionHandler<UpsertPurchaseOrderConnectorAction>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpsertPurchaseOrderConnectorAction));

        public void Handle(UpsertPurchaseOrderConnectorAction action)
        {
            //Purchase order upsert code
            try
            {
                using (var api = new ConnectorApi(action.source))
                {
                    Log.Info("Update Purchase Order");
                    api.UpdatePurchaseOrder(action.payload.purchaseOrder);
                    Log.Info($"Successfully Updated Purchase Order From MT: {action.payload.purchaseOrder.name}");
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
          
        }
    }
}
