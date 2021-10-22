using FluentValidation;
using TUSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models.Settings
{
    public class ChangePassword :BaseModel
    {
        public string Name { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    
}
