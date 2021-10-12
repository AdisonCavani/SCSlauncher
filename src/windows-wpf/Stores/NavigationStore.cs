using SCSlauncher.ViewModels;
using System;

namespace SCSlauncher.Stores
{
    //public class NavigationStore : INotifyPropertyChanged
    //{
    //    private ViewModelBase _currentViewModel;
    //    public ViewModelBase CurrentViewModel
    //    {
    //        get => _currentViewModel;
    //        set
    //        {
    //            _currentViewModel = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    #region EventHandlers
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    #endregion
    //}

    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
