using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Automation;

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
        }
    }
}
