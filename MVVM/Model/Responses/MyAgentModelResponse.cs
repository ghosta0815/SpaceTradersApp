namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// GET https://api.spacetraders.io/v2/my/agent
/// </summary>
public class MyAgentModelResponse
{
    /// <summary>
    /// The data retrieved after requesting the agent data
    /// </summary>
    public AgentModel? Data { get; set; }
}

