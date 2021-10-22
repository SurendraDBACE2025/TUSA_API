using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class RolePrivilegeModel : BaseModel
    {
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Privilege { get; set; } 
    }
}
