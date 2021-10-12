using SCSlauncher.Stores;
using SCSlauncher.ViewModels;
using SCSlauncher.Views;
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

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new
                {
                    main = new MainViewModel(),
                    view = new ViewManager(navigationStore),
                    process = new ProcessManager()
                }
            };
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
