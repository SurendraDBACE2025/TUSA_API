using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class UserModel:BaseModel
    {
        public string User_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Contact_Number { get; set; }
        public string Email_Address { get; set; }
        public string Password { get; set; }
        public int User_Type_Id { get; set; }
        public DateTime Last_Login_Time { get; set; }
        public DateTime Password_Changed_Date { get; set; }
        public string Activation_code { get; set; }
        public string Reset_Password_Date { get; set; }
        public DateTime Last_Reset_Attempt_Time { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryAt { get; set; }
        public string Is_Activated { get; set; }
        public string Is_Active { get; set; }
        public string Is_Deleted { get; set; }
    }
}
