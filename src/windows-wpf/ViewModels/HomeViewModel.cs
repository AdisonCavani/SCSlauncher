using SCSlauncher.Commands;
using System.Windows.Input;

namespace SCSlauncher.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel(Stores.NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore));
        }
    }
}
