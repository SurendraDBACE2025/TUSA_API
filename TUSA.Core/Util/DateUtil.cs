using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Core.Util
{
    public static class DateUtil
    {
        public static int CalculateAge(DateTime? dateOfBirth)
        {
            int age = 0;
            if (dateOfBirth.HasValue)
            {
                age = DateTime.Now.Year - dateOfBirth.Value.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.Value.DayOfYear)
                    age = age - 1;
            }
            return age;

        }
        public static DateTime DOBFromAge(int age)
        {
            int year = DateTime.Now.Year - age; 
            int month = DateTime.Now.Month; 
            var dateOfBirth = new DateTime(year, month, 1); 
            return dateOfBirth;
        }
    }
}
