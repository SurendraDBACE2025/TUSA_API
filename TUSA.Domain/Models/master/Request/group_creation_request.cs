using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.master.Request
{
    public class group_creation_request
    {
        public string group_Name { get; set; }
        public string organization_Name { get; set; }
        public string email_Id { get; set; }
        public string contact_First_Name { get; set; }
        public string contact_Last_Name { get; set; }
        //public bool same_For_User { get; set; }
    }
}
