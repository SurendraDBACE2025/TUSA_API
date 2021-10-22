using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class SettingsModel
    {
        public DateTime TodayDate { get { return DateTime.Now; } }
        public string NextNo { get; }
        public SettingsModel(string No)
        {
            NextNo = No;
        }
    }
}
