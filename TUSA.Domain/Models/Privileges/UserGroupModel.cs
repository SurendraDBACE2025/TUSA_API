using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.Privileges
{
    public class UserGroupModel:BaseModel
    {
        public int user_id { get; set; }
        public int role_id { get; set; }
        public int group_id { get; set; }
    }
}
