using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Core.Util
{
    public static class DecimalUtil
    {
        public static decimal ValueFromPercent(decimal value, decimal percent)
        {
            return value + Math.Round(value * (percent / 100), 0);
        }         
    }
}
