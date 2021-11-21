using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.master.Request
{
    public class group_user_creation_details
    {
        public string group_name { get; set; }
        public string group_desc { get; set; }
        public string organization_name { get; set; }
        public string email_id { get; set; }
        public string contact_First_Name { get; set; }
        public string contact_Last_Name { get; set; }
        public string contact_number { get; set; }
        public string password { get; set; }
    }
}
