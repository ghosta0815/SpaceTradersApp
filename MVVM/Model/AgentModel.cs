namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// A class representing an agent
/// </summary>
public class AgentModel
{
    /// <summary>
    /// The ID of the user account
    /// </summary>
    public string? AccountId { get; set; }

    /// <summary>
    /// The symbole (UID) of the agent)
    /// </summary>
    public string? Symbol { get; set; }
    
    /// <summary>
    /// The headquarters of the agent
    /// </summary>
    public string? Headquarters { get; set; }

    /// <summary>
    /// The current credit balance
    /// </summary>
    public int? Credits { get; set; }

    /// <summary>
    /// The starting faction of the agent
    /// </summary>
    public string? StartingFaction { get; set; }
}

