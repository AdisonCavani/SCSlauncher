using System;
using System.Diagnostics;

namespace SCSlauncher.Windows
{
    public class Run
    {
        public static void Test(string fileName, string arg)
        {
            try
            {
                Console.WriteLine("Trying to run ETS2");
                Process process = new Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arg;
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
