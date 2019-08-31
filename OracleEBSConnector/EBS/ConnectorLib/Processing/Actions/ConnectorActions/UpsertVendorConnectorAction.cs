using ConnectorModel.Payloads;

namespace ConnectorLib.Processing.Actions.ConnectorActions
{
    public class UpsertVendorConnectorAction : ConnectorAction
  {
        public VendorPayload payload { get; set; }
    }
}