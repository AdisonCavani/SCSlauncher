namespace SCSlauncher.Core
{
    public class ValidateProfile
    {
        /// <summary>
        /// Call validate methods, that check if setting has proper value
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>Valid profile</returns>
        public static Profile Validate(Profile profile)
        {
            // General settings
            profile.profileName = ProfileName(profile.profileName);
            profile.profileImage = ProfileImage(profile.profileImage);
            profile.steamPath = SteamPath(profile.steamPath);
            profile.homeDirectory = HomeDirectory(profile.homeDirectory);
            profile.homeDirectoryPath = HomeDirectoryPath(profile.homeDirectoryPath);
            profile.conversionDump = ConversionDump(profile.conversionDump);
            profile.conversionDumpPath = ConversionDumpPath(profile.conversionDumpPath);

            // ETS settings
            profile.ets.gameMode = GameMode(profile.ets.gameMode);
            profile.ets.modActivation = ModActivation(profile.ets.modActivation);
            profile.ets.renderDevice = RenderDevice(profile.ets.renderDevice);
            profile.ets.vrMode = VrMode(profile.ets.vrMode);
            profile.ets.logFile = LogFileMode(profile.ets.logFile);
            profile.ets.editorStartingMap = EditorStartingMap(profile.ets.editorStartingMap);
            profile.ets.noIntro = NoIntro(profile.ets.noIntro);
            profile.ets.force64bit = Force64bit(profile.ets.force64bit);
            profile.ets.unmountUserMap = UnmountUserMap(profile.ets.unmountUserMap);
            profile.ets.useDefaultMemorySettings = UseDefaultMemorySettings(profile.ets.useDefaultMemorySettings);

            // ATS settings
            profile.ats.gameMode = GameMode(profile.ats.gameMode);
            profile.ats.modActivation = ModActivation(profile.ats.modActivation);
            profile.ats.renderDevice = RenderDevice(profile.ats.renderDevice);
            profile.ats.vrMode = VrMode(profile.ats.vrMode);
            profile.ats.logFile = LogFileMode(profile.ats.logFile);
            profile.ats.editorStartingMap = EditorStartingMap(profile.ats.editorStartingMap);
            profile.ats.noIntro = NoIntro(profile.ats.noIntro);
            profile.ats.force64bit = Force64bit(profile.ats.force64bit);
            profile.ats.unmountUserMap = UnmountUserMap(profile.ats.unmountUserMap);
            profile.ats.useDefaultMemorySettings = UseDefaultMemorySettings(profile.ats.useDefaultMemorySettings);

            // Memory settings
            profile.ets.memorySettings.maxResourceSize = MaxResourceSize(profile.ets.memorySettings.maxResourceSize);
            profile.ets.memorySettings.maxTempBuffers = MaxTempBuffers(profile.ets.memorySettings.maxTempBuffers);
            profile.ats.memorySettings.maxResourceSize = MaxResourceSize(profile.ats.memorySettings.maxResourceSize);
            profile.ats.memorySettings.maxTempBuffers = MaxTempBuffers(profile.ats.memorySettings.maxTempBuffers);

            return profile;
        }

        #region General
        private static string ProfileName(object profileName)
        {
            if (profileName is string)
            {
                Debug.LogTrace("Profile name validated: " + profileName);
                return profileName as string;
            }

            Debug.LogWarning("Profile name couldn't be validated. Falling back to default value");
            return string.Empty;
        }

        private static string ProfileImage(object profileImage)
        {
            if (profileImage is string)
            {
                Debug.LogTrace("Profile image validated: " + profileImage);
                return profileImage as string;
            }

            Debug.LogWarning("Profile image couldn't be validated. Falling back to default value");
            return string.Empty;
        }

        private static string SteamPath(object steamPath)
        {
            if (steamPath is string)
            {
                Debug.LogTrace("Steam path validated: " + steamPath);
                return steamPath as string;
            }

            Debug.LogWarning("Steam path couldn't be validated. Falling back to default value");
            return string.Empty;
        }

        private static bool HomeDirectory(object homeDirectory)
        {
            if (homeDirectory is bool)
            {
                Debug.LogTrace("Home directory path validated: " + homeDirectory);
                return (bool)homeDirectory;
            }

            Debug.LogWarning("Home directory path couldn't be validated. Falling back to default value: false");
            return false;
        }

        private static string HomeDirectoryPath(object homeDirectoryPath)
        {
            if (homeDirectoryPath is string)
            {
                Debug.LogTrace("Home directory path validated: " + homeDirectoryPath);
                return homeDirectoryPath as string;
            }

            Debug.LogWarning("Home directory path couldn't be validated. Falling back to default value");
            return string.Empty;
        }

        private static bool ConversionDump(object conversionDump)
        {
            if (conversionDump is bool)
            {
                Debug.LogTrace("Conversion dump validated: " + conversionDump);
                return (bool)conversionDump;
            }

            Debug.LogWarning("Conversion dump couldn't be validated. Falling back to default value: false");
            return false;
        }

        private static string ConversionDumpPath(object conversionDumpPath)
        {
            if (conversionDumpPath is string)
            {
                Debug.LogTrace("Conversion dump path validated: " + conversionDumpPath);
                return conversionDumpPath as string;
            }

            Debug.LogWarning("Conversion dump path couldn't be validated. Falling back to default value");
            return string.Empty;
        }
        #endregion

        #region ETS & ATS
        private static int GameMode(object gameMode)
        {
            if (gameMode is int && (int)gameMode >= 0 && (int)gameMode <= 3)
            {
                Debug.LogTrace("Game mode validated: " + gameMode);
                return (int)gameMode;
            }

            Debug.LogWarning("Game mode couldn't be validated. Falling back to default value: 0");
            return 0;
        }

        private static int ModActivation(object modActivation)
        {
            if (modActivation is int && (int)modActivation >= 0 && (int)modActivation <= 3)
            {
                Debug.LogTrace("Game mode validated: " + modActivation);
                return (int)modActivation;
            }
            Debug.LogWarning("Mod activation couldn't be validated. Falling back to default value: 0");
            return 0;
        }

        private static int RenderDevice(object renderDevice)
        {
            if (renderDevice is int && (int)renderDevice >= 0 && (int)renderDevice <= 1)
            {
                Debug.LogTrace("Render device validated: " + renderDevice);
                return (int)renderDevice;
            }

            Debug.LogWarning("Render device couldn't be validated. Falling back to default value: 0");
            return 0;
        }

        private static int VrMode(object vrMode)
        {
            if (vrMode is int && (int)vrMode >= 0 && (int)vrMode <= 2)
            {
                Debug.LogTrace("VR mode validated: " + vrMode);
                return (int)vrMode;
            }

            Debug.LogWarning("VR mode couldn't be validated. Falling back to default value: 0");
            return 0;
        }

        private static int LogFileMode(object logFile)
        {
            if (logFile is int && (int)logFile >= 0 && (int)logFile <= 2)
            {
                Debug.LogTrace("Log file mode validated: " + logFile);
                return (int)logFile;
            }

            Debug.LogWarning("Log file string couldn't be validated. Falling back to default value: 0");
            return 0;
        }

        private static string EditorStartingMap(object editorStartingMap)
        {
            if (editorStartingMap is string)
            {
                Debug.LogTrace("Editor starting map validated: " + editorStartingMap);
                return editorStartingMap as string;
            }

            Debug.LogWarning("Editor starting map couldn't be validated. Falling back to default value");
            return string.Empty;
        }

        private static bool NoIntro(object noIntro)
        {
            if (noIntro is bool)
            {
                Debug.LogTrace("No intro validated: " + noIntro);
                return (bool)noIntro;
            }

            Debug.LogWarning("No intro couldn't be validated. Falling back to default value: false");
            return false;
        }

        private static bool Force64bit(object force64bit)
        {
            if (force64bit is bool)
            {
                Debug.LogTrace("Force 64 bit validated: " + force64bit);
                return (bool)force64bit;
            }

            Debug.LogWarning("Force 64 bit couldn't be validated. Falling back to default value: false");
            return false;
        }

        private static bool UnmountUserMap(object unmountUserMap)
        {
            if (unmountUserMap is bool)
            {
                Debug.LogTrace("Unmount user map validated: " + unmountUserMap);
                return (bool)unmountUserMap;
            }

            Debug.LogWarning("Unmount user map couldn't be validated. Falling back to default value: false");
            return false;
        }

        private static bool UseDefaultMemorySettings(object useDefaultMemorySettings)
        {
            if (useDefaultMemorySettings is bool)
            {
                Debug.LogTrace("Use default memory settings validated: " + useDefaultMemorySettings);
                return (bool)useDefaultMemorySettings;
            }

            Debug.LogWarning("Use default memory settings couldn't be validated. Falling back to default value: false");
            return false;
        }
        #endregion

        #region MemorySettings
        private static int MaxResourceSize(object maxResourceSize)
        {
            if (maxResourceSize is int && (int)maxResourceSize > 0 && (int)maxResourceSize <= 100)
            {
                Debug.LogTrace("-mm_max_resource_size validated: " + maxResourceSize);
                return (int)maxResourceSize;
            }

            Debug.LogWarning("-mm_max_resource_size couldn't be validated. Falling back to default value: 22");
            return 22;
        }

        private static int MaxTempBuffers(object maxTempBuffers)
        {
            if (maxTempBuffers is int && (int)maxTempBuffers > 0 && (int)maxTempBuffers <= 1000)
            {
                Debug.LogTrace("-mm_max_tmp_buffers_size validated: " + maxTempBuffers);
                return (int)maxTempBuffers;
            }

            Debug.LogWarning("-mm_max_tmp_buffers_size couldn't be validated. Falling back to default value: 112");
            return 112;
        }
        #endregion
    }
}
