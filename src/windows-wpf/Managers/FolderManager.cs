using System;

namespace SCSlauncher.Core
{
    public class FolderManager
    {
        //.
        //└── SCS Launcher
        //    └── profiles

        /// <summary>
        /// Generate folder structure
        /// </summary>
        public static void Initialize()
        {
            string programFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SCS Launcher";

            if (!FileManager.CheckForDirectory(programFolder))
            {
                FileManager.CreateDirectory(programFolder);
            }

            if (!FileManager.CheckForDirectory(programFolder + "\\profiles"))
            {
                FileManager.CreateDirectory(programFolder + "\\profiles");
            }
        }
    }
}
