namespace SpaceTradersApp.Core;

/// <summary>
/// Interface for the File handler of writing and reading token files
/// </summary>
public interface ITokenFileHandler
{
    /// <summary>
    /// Method to write the Token to a file
    /// </summary>
    public void WriteTokenToFile(string bearerToken, string agentName);

    /// <summary>
    /// Method to read a token from a file
    /// </summary>
    public string ReadTokenFromFile();
}
