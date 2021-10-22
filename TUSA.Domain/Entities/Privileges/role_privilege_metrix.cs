using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Entities.Privileges
{
    public class role_privilege_metrix : BaseEntity
    {
        public int role_id { get; set; }
        public role_master role { get; set; }
        public int privilege_id { get; set; }
        public privilege_master privilege { get; set; }
    }
}
