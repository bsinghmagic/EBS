using ConnectorModel.Payloads;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
    public class UpsertPurchaseOrderConnectorAction : ConnectorAction
  {
        public PurchaseOrderPayload payload { get; set; }
    }
}