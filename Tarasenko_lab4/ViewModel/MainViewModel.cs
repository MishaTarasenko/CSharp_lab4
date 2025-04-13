using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tarasenko_lab4.Managers;
using Tarasenko_lab4.Model;
using Tarasenko_lab4.Navigation;
using Tarasenko_lab4.Services;

namespace Tarasenko_lab4.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged, INavigatable
    {
        private readonly PersonService _personService;
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        private string _filterText;
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _filterCommand;
        private Action _navigateToAddUser;
        private Action _navigateToEditUser;

        public MainViewModel(Action navigateToAddUser, Action navigateToEditUser)
        {
            _navigateToAddUser = navigateToAddUser;
            _navigateToEditUser = navigateToEditUser;
            _personService = new PersonService();
            _persons = new ObservableCollection<Person>();
        }

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                DeleteCommand.NotifyCanExecuteChanged();
                EditCommand.NotifyCanExecuteChanged();
            }
        }

        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand => _addCommand ??= new RelayCommand(_navigateToAddUser);

        public RelayCommand EditCommand => _editCommand ??= new RelayCommand(_navigateToEditUser, hasPerson);

        public RelayCommand DeleteCommand => _deleteCommand ??= new RelayCommand(DeletePersonAsync, hasPerson);

        public RelayCommand FilterCommand => _filterCommand ??= new RelayCommand(FilterPersonsAsync);

        public MainNavigationTypes ViewType => MainNavigationTypes.Main;

        private bool hasPerson()
        {
            return SelectedPerson != null;
        }

        public async Task LoadPersonsAsync()
        {
            try
            {
                LoaderManager.Instance.ShowLoader();
                var persons = await _personService.GetAllUsersAsync();
                Persons = new ObservableCollection<Person>(persons);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading persons: {ex.Message}");
            }
            finally
            {
                LoaderManager.Instance.HideLoader();
            }
        }

        private async void DeletePersonAsync()
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    LoaderManager.Instance.ShowLoader();
                    await _personService.DeletePersonAsync(SelectedPerson.Email);
                    Persons.Remove(SelectedPerson);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting person: {ex.Message}");
                }
                finally
                {
                    LoaderManager.Instance.HideLoader();
                }
            }
        }

        private async void FilterPersonsAsync()
        {
            try
            {
                LoaderManager.Instance.ShowLoader();
                var allPersons = await _personService.GetAllUsersAsync();

                var filtered = string.IsNullOrWhiteSpace(FilterText)
                    ? allPersons
                    : allPersons.Where(p =>
                        p.Name.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                        p.LastName.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                        p.Email.Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                        p.SunSign.ToString().Contains(FilterText, StringComparison.OrdinalIgnoreCase) ||
                        p.ChineseSign.ToString().Contains(FilterText, StringComparison.OrdinalIgnoreCase)
                    );

                Persons = new ObservableCollection<Person>(filtered);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering persons: {ex.Message}");
            }
            finally
            {
                LoaderManager.Instance.HideLoader();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
