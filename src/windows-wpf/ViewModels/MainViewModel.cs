﻿using SCSlauncher.Commands;
using SCSlauncher.Core;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SCSlauncher.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            //Windows.Properties.Settings.Default.LogLevel = 4;
            Windows.Properties.Settings.Default.DarkTheme = true;
            //Windows.Properties.Settings.Default.LastProfile = @"C:\Users\Adison\Documents\SCS Launcher\profiles\A9SEWECDEZVK7L7OQ6OH\profile.json";
            Windows.Properties.Settings.Default.Save();

            FolderManager.Initialize();

            OneCommand = new RelayCommand(One);
            TwoCommand = new RelayCommand(Two);
            LaunchGameCommand = new RelayCommand(LaunchGame);
        }

        // Currently loaded profile
        public static Profile currentProfile = new Profile();

        #region Commands
        public ICommand OneCommand { get; set; }
        public ICommand TwoCommand { get; set; }
        public ICommand LaunchGameCommand { get; set; }
        #endregion

        static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = docsPath + @"\SCS Launcher\profiles";

        private void One(object obj)
        {
            Debug.Log("Clicked one");

            //ProfileManager.Refresh();

            //Profile validatedProfile = ValidateProfile.Validate(profile);
            //Args.ParseArgsATS(validatedProfile);
            //ProfileManager.CreateProfile(validatedProfile);
        }

        private void Two(object obj)
        {
            Debug.Log("Clicked two");
            //MessageBox.Show(currentProfile.profileName as string);
        }

        private void LaunchGame(object obj)
        {
            Profile validatedProfile = ValidateProfile.Validate(profile);

            if ((string)obj == "ats")
            {
                Debug.Log($"Using profile: \"{profile.profileName}\"");
                Game.Run((string)validatedProfile.steamPath, Args.ParseArgsATS(validatedProfile));
            }

            else if ((string)obj == "ets")
            {
                Debug.Log($"Using profile: \"{profile.profileName}\"");
                Game.Run((string)validatedProfile.steamPath, Args.ParseArgsETS(validatedProfile));
            }
        }

        Profile profile = new Profile
        {
            profileName = "Adison",
            profileImage = "",
            steamPath = "",
            homeDirectory = false,
            homeDirectoryPath = "",
            conversionDump = false,
            conversionDumpPath = "",

            ets = new Ets
            {
                gameMode = 0,
                modActivation = 0,
                renderDevice = 0,
                vrMode = 0,
                logFile = 0,
                editorStartingMap = "",
                noIntro = false,
                force64bit = false,
                unmountUserMap = false,
                useDefaultMemorySettings = true,

                memorySettings = new MemorySettings
                {
                    maxResourceSize = 22,
                    maxTempBuffers = 112,
                },

                etsDlc = new EtsDlc
                {
                    east = false,
                    north = false,
                    fr = false,
                    it = false,
                    balt = false,
                    balkan_e = false,
                    iberia = false,
                }
            },

            ats = new Ats
            {
                gameMode = 0,
                modActivation = 0,
                renderDevice = 0,
                vrMode = 0,
                logFile = 0,
                editorStartingMap = "",
                noIntro = false,
                force64bit = false,
                unmountUserMap = false,
                useDefaultMemorySettings = true,

                memorySettings = new MemorySettings
                {
                    maxResourceSize = 22,
                    maxTempBuffers = 112,
                },

                atsDlc = new AtsDlc
                {
                    nevada = false,
                    arizona = false,
                    nm = false,
                    or = false,
                    wa = false,
                    ut = false,
                    co = false,
                }
            }
        };

        #region EventHandlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
