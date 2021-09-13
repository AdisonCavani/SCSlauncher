using System.Diagnostics;

namespace SCSlauncher.Core
{
    public class ProcessManager
    {
        public static bool IsRunning(string processName)
        {
            Process[] pname = Process.GetProcessesByName(processName);

            if (pname.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
