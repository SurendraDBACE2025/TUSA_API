using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Entities.Privileges
{
    public class role_privilege_metrix : BaseEntity
    {
        public role_master role { get; set; }
        public privilege_master privilege { get; set; }
    }
}
