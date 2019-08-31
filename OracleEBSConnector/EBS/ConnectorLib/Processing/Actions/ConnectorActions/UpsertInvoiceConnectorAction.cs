using ConnectorModel.Payloads;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
    public class UpsertInvoiceConnectorAction : ConnectorAction
    {
        public InvoicePayload payload { get; set; }
    }
}