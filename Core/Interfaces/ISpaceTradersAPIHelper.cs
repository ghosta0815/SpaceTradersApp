using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core
{
    public interface ISpaceTradersAPIHelper
    {
        /// <summary>
        /// Sets the token for the API Calls
        /// </summary>
        internal string Token { get; set; }

        /// <summary>
        /// Gets the Account Data
        /// </summary>
        /// <returns></returns>
        Task<AgentModel?> getMyAgentAsync();

        /// <summary>
        /// Gets The List of Available Ships
        /// </summary>
        /// <returns></returns>
        Task<FleetModelResponse?> getShipsDataAsync();

        /// <summary>
        /// Registers a new Agent Account
        /// </summary>
        /// <param name="agentName">The name of the agent</param>
        /// <param name="selectedFaction">the selected faction</param>
        /// <returns></returns>
        Task<AccountModel?> RegisterNewAccountAsync(string agentName, string? selectedFaction);
    }
}