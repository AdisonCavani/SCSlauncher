using System;
using System.IO;

namespace SCSlauncher.Core
{
    public class FolderManager
    {
        private readonly static string programFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SCS Launcher";

        //.
        //└── SCS Launcher
        //    └── profiles

        /// <summary>
        /// Generate folder structure and lock all files
        /// </summary>
        public static void Initialize()
        {
            if (!FileManager.CheckForDirectory(programFolder))
            {
                FileManager.CreateDirectory(programFolder);
            }

            if (!FileManager.CheckForDirectory(programFolder + @"\profiles"))
            {
                FileManager.CreateDirectory(programFolder + @"\profiles");
            }

            Debug.Initialize();
            ProfileManager.Initialize();
            LockAllFiles();
        }

        public static void LockAllFiles()
        {
            var files = Directory.GetFiles(programFolder, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Debug.LogTrace($"Locked file: \"{file}\"");
            }
        }

        public static void LockFile(string filePath)
        {
            File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Debug.LogTrace($"Locked file: \"{filePath}\"");
        }
    }
}
