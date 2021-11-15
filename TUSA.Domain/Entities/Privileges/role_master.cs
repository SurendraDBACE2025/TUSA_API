using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TUSA.Domain.Entities.Privileges
{ 
    public partial class role_master : AuditEntity
    {
        [Key]
        public int role_id { get; set; }

        [MaxLength(50)]
        public string role_name { get; set; }
      
    }
}
