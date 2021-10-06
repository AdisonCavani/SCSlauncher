using System;
using System.Diagnostics;

namespace SCSlauncher.Core
{
    public class Game
    {
        public static void Run(string fileName, string arg)
        {
            try
            {
                Debug.Log("Launching game");
                Debug.Log($"Steam path: \"{fileName}\"");
                Debug.Log($"Arguments: \"{arg}\"");
                Process process = new Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arg;
                process.Start();
            }
            catch (Exception e)
            {
                Debug.LogException(e.Message);
            }
        }
    }
}
