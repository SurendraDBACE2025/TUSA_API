using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class project_scope_master:BaseEntity
    {
        [Key]
        public int project_scope_id { get; set; }
        [MaxLength(50)]
        public string project_scope_name { get; set; }
        [MaxLength(1000)]
        public string? project_scope_desc { get; set; }
    }
}
