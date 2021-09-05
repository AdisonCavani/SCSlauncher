using SCSlauncher.Core.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SCSlauncher.Core.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            //Windows.Properties.Settings.Default.LogLevel = 4;
            //Windows.Properties.Settings.Default.Save();
            FolderManager.Initialize();
            Debug.Initialize();
            ProfileManager.Initialize();

            Test = new RelayCommand(TestOne);
            TestTwo = new RelayCommand(TestTwoo);
        }

        public ICommand Test { get; set; }
        public ICommand TestTwo { get; set; }

        static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = docsPath + "\\SCS Launcher\\profiles";

        private void TestOne(object obj)
        {
            Debug.Log("Clicked one");

            Profile validatedProfile = ValidateProfile.Validate(profile);
            Args.ParseArgsATS(validatedProfile);
            ProfileManager.CreateProfile(validatedProfile);
        }

        private void TestTwoo(object obj)
        {
            Debug.Log("Clicked two");
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
