using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Core.Util
{
    public static class StringUtil
    {
       
        public static string NumberToWords(int value)
        {
            string words = numberToWordsRecursive(value);
            return words.Trim() + " Rupees Only";
        }
        private static string numberToWordsRecursive(int number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "minus " + numberToWordsRecursive(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += numberToWordsRecursive(number / 100000) + " Lak ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += numberToWordsRecursive(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += numberToWordsRecursive(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "And ";
                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}
