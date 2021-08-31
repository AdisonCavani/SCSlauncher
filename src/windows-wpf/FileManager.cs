using System.IO;

namespace SCSlauncher.Core
{
    public class FileManager
    {

        public static bool CheckForDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Creating directory: " + path);
            }
        }
    }
}
