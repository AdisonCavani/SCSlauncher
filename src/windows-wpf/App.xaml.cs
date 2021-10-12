using System;
using System.Windows;

namespace SCSlauncher.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //SetResourceDictionary();

            MainWindow = new MainWindow();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void SetResourceDictionary()
        {
            var lightTheme = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/Resources/LightTheme.xaml", UriKind.RelativeOrAbsolute)
            };

            var darkTheme = new ResourceDictionary()
            {
                Source = new Uri("pack://application:,,,/Resources/DarkTheme.xaml", UriKind.RelativeOrAbsolute)
            };

            if (SCSlauncher.Windows.Properties.Settings.Default.DarkTheme == false)
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(lightTheme);
            }

            else if (SCSlauncher.Windows.Properties.Settings.Default.DarkTheme == true)
            {
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(darkTheme);
            }
        }
    }
}
