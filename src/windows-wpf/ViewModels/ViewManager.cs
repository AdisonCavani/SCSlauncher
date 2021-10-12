using SCSlauncher.Stores;

namespace SCSlauncher.ViewModels
{
    public class ViewManager : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public ViewManager(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            OnPropertyChanged();
            //_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        //private void OnCurrentViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentViewModel));
        //}
    }
}
