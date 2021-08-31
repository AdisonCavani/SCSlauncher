﻿using Newtonsoft.Json;
using SCSlauncher.Core.Commands;
using SCSlauncher.Windows;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SCSlauncher.Core.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            //Windows.Properties.Settings.Default.LogLevel = 3;
            //Windows.Properties.Settings.Default.Save();
            Debug.Initialize();

            AddNumberCommand = new RelayCommand(AddNumber);
        }

        public ICommand AddNumberCommand { get; set; }

        static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = docsPath + "\\SCS Launcher\\profiles";

        private void AddNumber(object obj)
        {
            Debug.Log("Clicked");
            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);

            if (FileManager.CheckForDirectory(path))
            {
                File.WriteAllText(path + "\\profile.json", json);
                Debug.Log("Created profile: " + path + "\\profile.json");
            }

            else
            {
                Debug.Log("Program directory does not exist");
                FileManager.CreateDirectory(path);
                File.WriteAllText(path + "\\profile.json", json);
                Debug.Log("Created profile: " + path + "\\profile.json");
            }

            Profile deProfile = JsonConvert.DeserializeObject<Profile>(json);
            MessageBox.Show(deProfile.logFilePath);
        }

        Profile profile = new Profile
        {
            profileName = "",
            profileImage = "",
            steamPath = "",
            homeDirectory = false,
            homeDirectoryPath = "",
            conversionDump = false,
            conversionDumpPath = "",
            logFile = false,
            logFilePath = "test",

            ets = new Ets
            {
                gameMode = "",
                modActivation = "",
                renderDevice = "",
                vrMode = "",
                logFile = "",
                editorStartingMap = "",
                noIntro = false,
                force64bit = false,
                unmountUserMap = false,
                useDefaultMemorySettings = false,

                etsMemorySettings = new MemorySettings
                {
                    maxResourceSize = 0,
                    maxTempBuffers = 0,
                    poolSize = 0,
                    maxMemory = 0,
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
                gameMode = "",
                modActivation = "",
                renderDevice = "",
                vrMode = "",
                logFile = "",
                editorStartingMap = "",
                noIntro = false,
                force64bit = false,
                unmountUserMap = false,
                useDefaultMemorySettings = false,

                atsMemorySettings = new MemorySettings
                {
                    maxResourceSize = 0,
                    maxTempBuffers = 0,
                    poolSize = 0,
                    maxMemory = 0,
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
