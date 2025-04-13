using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
using Tarasenko_lab4.Validators;

namespace Tarasenko_lab4.ViewModel
{
    public class EditUserViewModel : INotifyPropertyChanged, INavigatable
    {
        private readonly PersonService _personService;
        private Person _person;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private Action _editAndGoToMainView;
        private Action _goToMainView;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;

        public EditUserViewModel(Action editAndGoToMainView, Action goToMainView, Person personToEdit)
        {
            _editAndGoToMainView = editAndGoToMainView;
            _goToMainView = goToMainView;
            _personService = new PersonService();

            _firstName = personToEdit.Name;
            _lastName = personToEdit.LastName;
            _email = personToEdit.Email;
            _birthDate = personToEdit.BirthDate;
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

        public RelayCommand SaveCommand => _saveCommand ??= new RelayCommand(EditPersonAsync);

        public RelayCommand CancelCommand => _cancelCommand ??= new RelayCommand(_goToMainView);

        private async void EditPersonAsync()
        {
            if (!ValidatePerson()) return;

            try
            {
                LoaderManager.Instance.ShowLoader();
                var editedPerson = new Person(FirstName, LastName, Email, BirthDate);
                await _personService.UpdatePerson(editedPerson);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving person: {ex.Message}");
            }
            finally
            {
                LoaderManager.Instance.HideLoader();
                _editAndGoToMainView.Invoke();
            }
        }

        private bool ValidatePerson()
        {
            try
            {
                DataValidator.ValidateName(_firstName);
                DataValidator.ValidateLastName(_lastName);
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
