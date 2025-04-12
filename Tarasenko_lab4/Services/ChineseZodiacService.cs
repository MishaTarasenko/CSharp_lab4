using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasenko_lab4.Exceptions;
using Tarasenko_lab4.Model.Enums;

namespace Tarasenko_lab4.Services
{
    public static class ChineseZodiacService
    {
        public static ChineseZodiacSign GetChineseZodiac(DateTime birthDate)
        {
            if (birthDate.Year < 4) throw new BirthDateOutOfRangeException();

            int offset = (birthDate.Year - 4) % 12;
            return (ChineseZodiacSign)offset;
        }

    }
}
