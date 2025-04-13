using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tarasenko_lab4.Managers;
using Tarasenko_lab4.Model.Enums;
using Tarasenko_lab4.Navigation;

namespace Tarasenko_lab4.ViewModel
{
    public class ProgramViewModel : INotifyPropertyChanged, ILoaderOwner
    {
        private INavigatable _currentViewModel;
        private MainViewModel _mainViewModel;
        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;

        public INavigatable CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public ProgramViewModel()
        {
            LoaderManager.Instance.Initialize(this);
            _mainViewModel = new MainViewModel(NavigateToAddUser, NavigateToEditUser);
            CurrentViewModel = _mainViewModel;
            Task.Run(() => _mainViewModel.LoadPersonsAsync());
        }

        private void NavigateToAddUser()
        {
            CurrentViewModel = new AddUserViewModel(async () =>
            {
                CurrentViewModel = _mainViewModel;
                await _mainViewModel.LoadPersonsAsync();
            },() =>
            {
                CurrentViewModel = _mainViewModel;
            });
        }

        private void NavigateToEditUser()
        {
            if (_mainViewModel.SelectedPerson == null) return;

            CurrentViewModel = new EditUserViewModel(async () =>
            {
                CurrentViewModel = _mainViewModel;
                await _mainViewModel.LoadPersonsAsync();
            }, () =>
            {
                CurrentViewModel = _mainViewModel;
            }, _mainViewModel.SelectedPerson);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
