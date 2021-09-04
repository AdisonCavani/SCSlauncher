using System;
using System.Diagnostics;

namespace SCSlauncher.Core
{
    public class Run
    {
        public static void RunGame(string fileName, string arg)
        {
            try
            {
                Debug.Log("Running: " + fileName);
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
