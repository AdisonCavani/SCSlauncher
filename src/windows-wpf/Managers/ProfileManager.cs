using SCSlauncher.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace SCSlauncher.Core
{
    public class ProfileManager
    {
        /// <summary>
        /// Fetch profile list and check if last profile exist
        /// </summary>
        public static void Initialize()
        {
            GetProfileList(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SCS Launcher\profiles\");
            Refresh();

        }

        /// <summary>
        /// Refresh info about profile in use
        /// </summary>
        public static void Refresh()
        {
            string lastProfile = Windows.Properties.Settings.Default.LastProfile;

            if (LastProfileExist(lastProfile))
            {
                Profile profile = Json.DeserializeProfile(lastProfile);
                profile = ValidateProfile.Validate(profile);

                MainViewModel.currentProfile = profile;
            }

        }

        /// <summary>
        /// Create .json profile with unique UserID
        /// </summary>
        /// <param name="profile"></param>
        public static void CreateProfile(Profile profile)
        {
            string profileFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SCS Launcher\profiles\";
            string json = Json.SerializeProfile(profile);
            string uid = UserID.GenerateUserID();

            while (FileManager.CheckForDirectory(profileFolder + uid))
            {
                uid = UserID.GenerateUserID();
            }

            FileManager.CreateFile(profileFolder + uid, @"\profile.json", json);
        }

        /// <summary>
        /// Check if profile exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool LastProfileExist(string path)
        {
            if (File.Exists(path) && !string.IsNullOrWhiteSpace(path))
            {
                Debug.LogTrace("Last profile exist in: " + path);
                return true;
            }

            else if (!string.IsNullOrWhiteSpace(path))
            {
                Debug.LogWarning("Last profile couldn't be found in: \"" + path + "\"");
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Array of existing profiles</returns>
        private static string[] GetProfileList(string path)
        {
            string[] profiles = Directory.GetDirectories(path);
            List<string> existingProfiles = new List<string>();
            List<string> notExistingProfiles = new List<string>();

            foreach (var profile in profiles)
            {
                if (File.Exists(profile + @"\profile.json"))
                {
                    existingProfiles.Add(profile);
                }

                if (!File.Exists(profile + @"\profile.json"))
                {
                    notExistingProfiles.Add(profile);
                }
            }

            foreach (var profile in existingProfiles)
            {
                Debug.Log($"Found valid profile: \"{profile}\"");
            }

            foreach (var profile in notExistingProfiles)
            {
                Debug.LogWarning($"Missing profile.json in: \"{profile}\"");
            }

            return existingProfiles.ToArray();
        }

    }
}
