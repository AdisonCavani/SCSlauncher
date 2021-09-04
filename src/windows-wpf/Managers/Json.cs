using Newtonsoft.Json;
using System;
using System.IO;

namespace SCSlauncher.Core
{
    public class Json
    {
        /// <summary>
        /// Serialize .json profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static string SerializeProfile(Profile profile)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profile, Formatting.Indented);
                Debug.Log("Serialized profile: " + profile.profileName);

                return json;
            }

            catch (Exception e)
            {
                Debug.LogException(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Deserialize .json profile
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Deserialized profile</returns>
        public static Profile DeserializeProfile(string filePath)
        {
            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Profile profile = (Profile)serializer.Deserialize(file, typeof(Profile));
                        Debug.Log("Deserialized profile: " + profile.profileName);

                        return profile;
                    }

                    catch (Exception e)
                    {
                        Debug.LogException(e.Message);
                        return null;
                    }
                }
            }

            catch (Exception e)
            {
                Debug.LogException(e.Message);
                return null;
            }
        }
    }
}
