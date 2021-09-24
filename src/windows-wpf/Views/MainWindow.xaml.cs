using SCSlauncher.Core.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace SCSlauncher.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
