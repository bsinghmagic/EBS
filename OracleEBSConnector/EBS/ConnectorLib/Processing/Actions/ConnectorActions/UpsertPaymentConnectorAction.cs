using ConnectorModel.Payloads;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
    public class UpsertPaymentConnectorAction : ConnectorAction
  {
        public PaymentPayload payload { get; set; }
    }
}