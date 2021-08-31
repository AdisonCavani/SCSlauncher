using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
