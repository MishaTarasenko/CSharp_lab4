using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Model.Enums;
using Tarasenko_lab4.Services;
using Tarasenko_lab4.Validators;

namespace Tarasenko_lab4.Model
{
    internal class Person
    {

        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;

        private readonly bool _isAdult;
        private readonly WesternZodiacSign _sunSign;
        private readonly ChineseZodiacSign _chineseSign;
        private readonly bool _isBirthday;

        public Person(string name, string lastName, string email, DateTime birthDate)
        {
            DataValidator.ValidateName(name);
            DataValidator.ValidateLastName(lastName);
            DataValidator.ValidateEmail(email);
            DataValidator.ValidateBirthDate(birthDate);

            _name = name;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;

            _isAdult = PersonService.IsAdult(_birthDate);
            _sunSign =  WesternZodiacService.GetWesternZodiac(_birthDate);
            _chineseSign = ChineseZodiacService.GetChineseZodiac(_birthDate);
            _isBirthday = PersonService.IsTodayBirthday(_birthDate);
        }

        public Person(string name, string lastName, string email)
            : this(name, lastName, email, DateTime.Today) { }

        public Person(string name, string lastName, DateTime birthDate)
            : this(name, lastName, string.Empty, birthDate) { }

        public string Name
        {
            get { return _name; }
            set
            {
                DataValidator.ValidateName(value);
                _name = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                DataValidator.ValidateLastName(value);
                _lastName = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                DataValidator.ValidateEmail(value);
                _email = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                DataValidator.ValidateBirthDate(value);
                _birthDate = value;
            }
        }

        public bool IsAdult => _isAdult;

        public WesternZodiacSign SunSign => _sunSign;

        public ChineseZodiacSign ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;
    }
}
