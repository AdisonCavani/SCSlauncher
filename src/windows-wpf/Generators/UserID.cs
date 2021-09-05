using System;

namespace SCSlauncher.Core
{
    public static class UserID
    {
        /// <summary>
        /// Generate unique UserID
        /// </summary>
        /// <returns>UserID</returns>
        public static string GenerateUserID()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[20];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
