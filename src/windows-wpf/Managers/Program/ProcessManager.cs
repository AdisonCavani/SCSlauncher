using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;

namespace SCSlauncher.ViewModels
{
    public class ProcessManager : INotifyPropertyChanged
    {
        public ProcessManager()
        {
            #region Timers
            Timer atsTimer = new Timer
            {
                Interval = Windows.Properties.Settings.Default.RefreshTime * 1000,
                AutoReset = true,
                Enabled = true
            };

            atsTimer.Elapsed += IsAtsRunning;

            Timer etsTimer = new Timer
            {
                Interval = Windows.Properties.Settings.Default.RefreshTime * 1000,
                AutoReset = true,
                Enabled = true
            };

            etsTimer.Elapsed += IsEtsRunning;
            #endregion
        }

        #region Ctors
        private bool _atsRunning;

        public bool AtsRunning
        {
            get { return _atsRunning; }
            set
            {
                _atsRunning = value;
                OnPropertyChanged();
            }
        }

        private bool _etsRunning;

        public bool EtsRunning
        {
            get { return _etsRunning; }
            set
            {
                _etsRunning = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void IsAtsRunning(object source, ElapsedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("americantrucks");

            if (pname.Length == 0)
            {
                AtsRunning = false;
            }
            else
            {
                AtsRunning = true;
            }
        }

        private void IsEtsRunning(object source, ElapsedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("eurotrucks2");

            if (pname.Length == 0)
            {
                EtsRunning = false;
            }
            else
            {
                EtsRunning = true;
            }
        }

        #region EventHandlers
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
