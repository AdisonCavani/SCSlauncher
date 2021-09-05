using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace SCSlauncher.Core
{
    public static class Debug
    {
        public static Stopwatch sw = Stopwatch.StartNew();
        private static string programPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SCS Launcher";
        private static string logFile = "\\app.log";
        private static string logPath = programPath + logFile;
        private static CultureInfo cultureInfo = new CultureInfo("en-US", false); // Date formatting to English

        /// <summary>
        /// Create program directory, if it doesn't exist. Get initial log content and create log file
        /// </summary>
        public static void Initialize()
        {
            string content = InitializeLogContent();
            CreateLog(programPath + logFile, content);
        }

        /// <summary>
        /// Append message to log
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="logLevelString"></param>
        /// <param name="logLevel"></param>
        private static void AppendMessage(string logMessage, string logLevelString, int logLevel)
        {
            if (logLevel >= 0 && logLevel <= Windows.Properties.Settings.Default.LogLevel)
            {
                string message = sw.Elapsed + "  " + logLevelString + ": " + logMessage + "\n";
                File.AppendAllText(logPath, message);
            }
        }

        /// <summary>
        /// Create log file with content
        /// </summary>
        /// <param name="logPath"></param>
        /// <param name="content"></param>
        private static void CreateLog(string logPath, string content)
        {
            File.WriteAllText(logPath, content);
        }

        /// <summary>
        /// Create initial log content
        /// </summary>
        /// <returns></returns>
        private static string InitializeLogContent()
        {
            string initMessage = $"****************  Log created on: {DateTime.Now.ToString("dddd", cultureInfo)}, {DateTime.Now.ToString("dd MMMM yyyy", cultureInfo)} @ {DateTime.Now.ToString("T")}";

            initMessage += "\n" + new string('=', initMessage.Length) + "\n";

            return initMessage;
        }

        #region Debug.Log methods
        /// <summary>
        /// Append message with type "Debug" to log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void LogTrace(string logMessage)
        {
            AppendMessage(logMessage, "Debug", 4);
        }
        /// <summary>
        /// Append message with type "Info" to log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void Log(string logMessage)
        {
            AppendMessage(logMessage, "Info", 3);
        }

        /// <summary>
        /// Append message with type "Warning" to log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void LogWarning(string logMessage)
        {
            AppendMessage(logMessage, "Warning", 2);
        }

        /// <summary>
        /// Append message with type "Exception" to log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void LogException(string logMessage)
        {
            AppendMessage(logMessage, "Exception", 1);
        }

        /// <summary>
        /// Append message with type "Error" to log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void LogError(string logMessage)
        {
            AppendMessage(logMessage, "Error", 0);
        }
        #endregion
    }
}
