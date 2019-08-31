namespace ConnectorLib.Processing.Actions.ConnectorActions.Factory
{
    /// <summary>
    /// Provides Interface to create Acton from some object (i.e. JSON string)
    /// </summary>
    public interface IActionFactory
    {
        ConnectorAction Create(string json);
    }
}