using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Domain.Entities
{
    public class user_group_metrix : BaseEntity
    {
        public int user_email_id { get; set; }
        public int role_id { get; set; }
        public int group_id { get; set; }
        public user_master user_master { get; set; }
        public role_master role_master { get; set; }
        public group_master group_master { get; set; }
    }
}
