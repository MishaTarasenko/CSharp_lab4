using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Model.Enums;

namespace Tarasenko_lab4.Services
{
    public static class WesternZodiacService
    {
        public static WesternZodiacSign GetWesternZodiac(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return WesternZodiacSign.Aries;
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return WesternZodiacSign.Taurus;
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return WesternZodiacSign.Gemini;
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return WesternZodiacSign.Cancer;
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return WesternZodiacSign.Leo;
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return WesternZodiacSign.Virgo;
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return WesternZodiacSign.Libra;
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return WesternZodiacSign.Scorpio;
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return WesternZodiacSign.Sagittarius;
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return WesternZodiacSign.Capricorn;
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return WesternZodiacSign.Aquarius;
            else
                return WesternZodiacSign.Pisces;
        }
    }
}
