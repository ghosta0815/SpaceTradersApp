using Microsoft.Win32;
using System;
using System.IO;

namespace SpaceTradersApp.Core;

/// <summary>
/// File Handler for reading and writing token files
/// </summary>
public class TokenFileHandler : ITokenFileHandler
{
    /// <summary>
    /// Writes the token to a file
    /// </summary>
    /// <param name="bearerToken">The bearer token that shall be written</param>
    public void WriteTokenToFile(string bearerToken, string agentName)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "SpaceTradersToken | *.stt";
        saveFileDialog.DefaultExt = "stt";
        if (saveFileDialog.ShowDialog() == true)
            File.WriteAllText(saveFileDialog.FileName, $"{DateTime.Now}\n{agentName}\n{bearerToken}");
    }

    /// <summary>
    /// Reads the token from a file
    /// </summary>
    /// <returns></returns>
    string ITokenFileHandler.ReadTokenFromFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "SpaceTradersToken | *.stt";
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == true)
        {
            var fileStream = openFileDialog.OpenFile();

            using (StreamReader reader = new StreamReader(fileStream))
            {
                string tokenFileText = reader.ReadToEnd();
                try
                {
                    string[] parts = tokenFileText.Split("\n");
                    return parts[2].Trim();

                }
                catch
                {
                    return "";
                }
            }
        }
        return "";
    }
}
