using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.User.Request
{
   public class user_request 
    {
        public int group_id { get; set; }
        public string email_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string contact_number { get; set; }
    }
}
