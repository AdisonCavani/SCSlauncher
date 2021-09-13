using System;
using System.Diagnostics;

namespace SCSlauncher.Core
{
    public class RunGame
    {
        public static void ATS(string fileName, string arg)
        {
            try
            {
                Debug.Log("Launching ATS");
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

        public static void ETS(string fileName, string arg)
        {
            try
            {
                Debug.Log($"Launching ETS2");
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
