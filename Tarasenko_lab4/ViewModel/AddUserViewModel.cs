using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tarasenko_lab4.Managers;
using Tarasenko_lab4.Model;
using Tarasenko_lab4.Navigation;
using Tarasenko_lab4.Services;
using Tarasenko_lab4.Validators;
using Tarasenko_lab4.Exceptions;
using System.Runtime.CompilerServices;

namespace Tarasenko_lab4.ViewModel
{
    public class AddUserViewModel : INotifyPropertyChanged, INavigatable
    {
        private readonly PersonService _personService;
        private RelayCommand _addCommand;
        private RelayCommand _cancelCommand;
        private Action _saveAndGoToMainView;
        private Action _goToMainView;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;

        public AddUserViewModel(Action saveAndGoToMainView, Action goToMainView)
        {
            _saveAndGoToMainView = saveAndGoToMainView;
            _goToMainView = goToMainView;
            _personService = new PersonService();

            _firstName = "";
            _lastName = "";
            _email = "";
            _birthDate = DateTime.Today;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand => _addCommand ??= new RelayCommand(AddPersonAsync);

        public RelayCommand CancelCommand => _cancelCommand ??= new RelayCommand(_goToMainView);

        private async void AddPersonAsync()
        {
            if (!ValidatePerson()) return;

            try
            {
                LoaderManager.Instance.ShowLoader();
                var newPerson = new Person(FirstName, LastName, Email, BirthDate);
                await _personService.AddPerson(newPerson);
            }
            catch (PersonAlreadyExistsException)
            {
                MessageBox.Show("User with this email already exists");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding person: {ex.Message}");
            }
            finally
            {
                LoaderManager.Instance.HideLoader();
                _saveAndGoToMainView.Invoke();
            }
        }

        private bool ValidatePerson()
        {
            try
            {
                DataValidator.ValidateName(_firstName);
                DataValidator.ValidateLastName(_lastName);
                DataValidator.ValidateEmail(_email);
                DataValidator.ValidateBirthDate(_birthDate);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
