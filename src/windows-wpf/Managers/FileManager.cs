using System.IO;

namespace SCSlauncher.Core
{
    public class FileManager
    {
        /// <summary>
        /// Check if directory exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool CheckForDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create directory if it doesn't exist
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Created directory: \"" + path + "\"");
            }
        }

        /// <summary>
        /// Create file with content
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="profile"></param>
        public static void CreateFile(string path, string fileName, string content)
        {
            if (FileManager.CheckForDirectory(path))
            {
                File.WriteAllText(path + fileName, content);
                Debug.Log("Created file: \"" + path + fileName + "\"");
            }

            else
            {
                FileManager.CreateDirectory(path);
                File.WriteAllText(path + fileName, content);
                Debug.Log("Created file: \"" + path + fileName + "\"");
            }
        }
    }
}
