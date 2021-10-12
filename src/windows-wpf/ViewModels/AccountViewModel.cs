using SCSlauncher.Commands;
using SCSlauncher.Stores;
using System.Windows.Input;

namespace SCSlauncher.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
        }
    }
}
