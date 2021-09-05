using System;
using System.Diagnostics;

namespace SCSlauncher.Core
{
    public class RunGame
    {
        public static void RunETS(string fileName, string arg)
        {
            try
            {
                Debug.Log("Running ETS2 \"{fileName}\"");
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

        public static void RunATS(string fileName, string arg)
        {
            try
            {
                Debug.Log($"Running ATS: \"{fileName}\"");
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
