using System.Text;

namespace SCSlauncher.Core
{
    public class Args
    {
        public static string ParseArgsATS(Profile profile)
        {
            string arg = string.Empty;
            int ats = 0;

            arg += "-applaunch 270880";
            arg += GameMode(profile, ats);
            arg += ModActivation(profile, ats);
            arg += RenderDevice(profile, ats);
            arg += VrMode(profile, ats);
            arg += LogFile(profile, ats);
            arg += NoIntro(profile, ats);
            arg += Force64bit(profile, ats);
            arg += UnmountUserMap(profile, ats);
            arg += MemorySettings(profile, ats);
            arg += HomeDirectory(profile);
            arg += ConversionDump(profile);

            // Add space between '-' character
            arg = AppendSpace(arg);

            Debug.LogTrace(arg);
            return arg;
        }

        public static string ParseArgsETS(Profile profile)
        {
            string arg = string.Empty;
            int ets = 1;

            arg = "-applaunch 227300";
            arg += GameMode(profile, ets);
            arg += ModActivation(profile, ets);
            arg += RenderDevice(profile, ets);
            arg += VrMode(profile, ets);
            arg += LogFile(profile, ets);
            arg += NoIntro(profile, ets);
            arg += Force64bit(profile, ets);
            arg += UnmountUserMap(profile, ets);
            arg += MemorySettings(profile, ets);
            arg += HomeDirectory(profile);
            arg += ConversionDump(profile);

            // Add space between '-' character
            arg = AppendSpace(arg);

            Debug.LogTrace(arg);
            return arg;
        }

        private static string GameMode(Profile profile, int game)
        {
            if (game == 0)
            {
                if ((int)profile.ats.gameMode == 1)
                {
                    if (profile.ats.editorStartingMap.ToString().Length > 0)
                    {
                        return "-edit " + profile.ats.editorStartingMap.ToString();
                    }
                    return "-edit";
                }

                else if ((int)profile.ats.gameMode == 2)
                {
                    if (profile.ats.editorStartingMap.ToString().Length > 0)
                    {
                        return "-edit " + profile.ats.editorStartingMap.ToString() + "-sound";
                    }
                    return "-edit" + "-sound";
                }

                else if ((int)profile.ats.gameMode == 3)
                {
                    return "-validate";
                }
            }

            else if (game == 1)
            {
                if ((int)profile.ets.gameMode == 1)
                {
                    if (profile.ets.editorStartingMap.ToString().Length > 0)
                    {
                        return "-edit " + profile.ets.editorStartingMap.ToString();
                    }
                    return "-edit";
                }

                else if ((int)profile.ets.gameMode == 2)
                {
                    if (profile.ets.editorStartingMap.ToString().Length > 0)
                    {
                        return "-edit " + profile.ets.editorStartingMap.ToString() + "-sound";
                    }
                    return "-edit" + "-sound";
                }

                else if ((int)profile.ets.gameMode == 3)
                {
                    return "-validate";
                }
            }

            return string.Empty;
        }

        private static string ModActivation(Profile profile, int game)
        {
            if (game == 0)
            {
                if ((int)profile.ats.modActivation == 1)
                {
                    return "-force_mods";
                }

                else if ((int)profile.ats.modActivation == 2)
                {
                    return "-force_mods" + "-noworkshop";
                }

                else if ((int)profile.ats.modActivation == 3)
                {
                    return "-noworkshop";
                }

                else if ((int)profile.ats.modActivation == 4)
                {
                    return "-pure";
                }
            }

            else if (game == 1)
            {
                if ((int)profile.ets.modActivation == 1)
                {
                    return "-force_mods";
                }

                else if ((int)profile.ets.modActivation == 2)
                {
                    return "-force_mods" + "-noworkshop";
                }

                else if ((int)profile.ets.modActivation == 3)
                {
                    return "-noworkshop";
                }

                else if ((int)profile.ets.modActivation == 4)
                {
                    return "-pure";
                }
            }

            return string.Empty;
        }

        private static string RenderDevice(Profile profile, int game)
        {
            if (game == 0)
            {
                if ((int)profile.ats.renderDevice == 0)
                {
                    return "-rdevice dx11";
                }

                else if ((int)profile.ats.renderDevice == 1)
                {
                    return "-rdevice gl";
                }
            }

            else if (game == 1)
            {
                if ((int)profile.ets.renderDevice == 0)
                {
                    return "-rdevice dx11";
                }

                else if ((int)profile.ets.renderDevice == 1)
                {
                    return "-rdevice gl";
                }
            }

            return string.Empty;
        }

        private static string VrMode(Profile profile, int game)
        {
            if (game == 0)
            {
                if ((int)profile.ats.vrMode == 1)
                {
                    return "-openvr";
                }

                else if ((int)profile.ats.vrMode == 2)
                {
                    return "-oculus";
                }
            }

            else if (game == 1)
            {
                if ((int)profile.ets.vrMode == 1)
                {
                    return "-openvr";
                }

                else if ((int)profile.ets.vrMode == 2)
                {
                    return "-oculus";
                }
            }

            return string.Empty;
        }

        private static string LogFile(Profile profile, int game)
        {
            if (game == 0)
            {
                if ((int)profile.ats.logFile == 1)
                {
                    return "-unlimitedlog";
                }

                else if ((int)profile.ats.logFile == 2)
                {
                    return "-nofilelog";
                }
            }

            else if (game == 1)
            {
                if ((int)profile.ets.logFile == 1)
                {
                    return "-unlimitedlog";
                }

                else if ((int)profile.ets.logFile == 2)
                {
                    return "-nofilelog";
                }
            }

            return string.Empty;
        }

        private static string NoIntro(Profile profile, int game)
        {
            if (game == 0 && (bool)profile.ats.noIntro)
            {
                return "-nointro";
            }

            else if (game == 1 && (bool)profile.ets.noIntro)
            {
                return "-nointro";
            }

            return string.Empty;
        }

        private static string Force64bit(Profile profile, int game)
        {
            if (game == 0 && (bool)profile.ats.force64bit)
            {
                return "-64bit";
            }

            else if (game == 1 && (bool)profile.ets.force64bit)
            {
                return "-64bit";
            }

            return string.Empty;
        }

        private static string UnmountUserMap(Profile profile, int game)
        {
            if (game == 0 && (bool)profile.ats.unmountUserMap)
            {
                return "-no_user_map_mount";
            }

            else if (game == 1 && (bool)profile.ets.unmountUserMap)
            {
                return "-no_user_map_mount";
            }

            return string.Empty;
        }

        private static string MemorySettings(Profile profile, int game)
        {
            if (game == 0 && !(bool)profile.ats.useDefaultMemorySettings)
            {
                return "-mm_max_resource_size " + profile.ats.memorySettings.maxResourceSize + "-mm_max_tmp_buffers_size " + profile.ats.memorySettings.maxTempBuffers;
            }

            else if (game == 1 && !(bool)profile.ets.useDefaultMemorySettings)
            {
                return "-mm_max_resource_size " + profile.ets.memorySettings.maxResourceSize + "-mm_max_tmp_buffers_size " + profile.ets.memorySettings.maxTempBuffers;
            }

            return string.Empty;
        }

        private static string HomeDirectory(Profile profile)
        {
            if ((bool)profile.homeDirectory)
            {
                return "-homedir " + profile.homeDirectoryPath;
            }

            return string.Empty;
        }

        private static string ConversionDump(Profile profile)
        {
            if ((bool)profile.conversionDump)
            {
                return "-homedir " + profile.conversionDumpPath;
            }

            return string.Empty;
        }

        private static string AppendSpace(string text)
        {
            StringBuilder newText = new StringBuilder(text.Length * 1, 2);
            newText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '-' && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }

            return newText.ToString();
        }
    }
}
