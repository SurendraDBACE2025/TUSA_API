using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.Privileges
{
    public class RolePrivilegeModel:BaseModel
    {
        public int role_id { get; set; }
        public int privilege_id { get; set; }
    }
}
