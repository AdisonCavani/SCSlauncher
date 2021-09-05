using System;
using System.Collections.Generic;
using System.IO;

namespace SCSlauncher.Core
{
    public class ProfileManager
    {
        public static void Initialize()
        {
            GetProfileList(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SCS Launcher\\profiles\\");
            LastProfileExist(Windows.Properties.Settings.Default.LastProfile);
        }

        public static void CreateProfile(Profile profile)
        {
            string profileFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SCS Launcher\\profiles\\";
            string json = Json.SerializeProfile(profile);
            string uid = UserID.GenerateUserID();

            while (FileManager.CheckForDirectory(profileFolder + uid))
            {
                uid = UserID.GenerateUserID();
            }

            FileManager.CreateFile(profileFolder + uid, "\\profile.json", json);
        }

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

        private static string[] GetProfileList(string path)
        {
            string[] profiles = Directory.GetDirectories(path);
            List<string> validProfiles = new List<string>();
            List<string> notValidProfiles = new List<string>();

            foreach (var profile in profiles)
            {
                if (File.Exists(profile + "\\profile.json"))
                {
                    validProfiles.Add(profile);
                }

                if (!File.Exists(profile + "\\profile.json"))
                {
                    notValidProfiles.Add(profile);
                }
            }

            foreach (var profile in validProfiles)
            {
                Debug.Log("Found valid profile: \"" + profile + "\"");
            }

            foreach (var profile in notValidProfiles)
            {
                Debug.LogWarning("Missing profile.json in: \"" + profile + "\"");
            }

            return validProfiles.ToArray();
        }

    }
}
