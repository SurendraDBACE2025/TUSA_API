using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Entities.UserMaster;

namespace TUSA.Domain.Entities.Privileges
{
    public class user_group_metrix: BaseEntity
    {
        public string user_name { get; set; }
        public user_master user { get; set; }
        public int role_id { get; set; }
        public role_master role { get; set; }
        public int group_id { get; set; }
        public group_master group { get; set; }
    }
}
