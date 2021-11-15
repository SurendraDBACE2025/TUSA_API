using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class project_phase_master:BaseEntity
    {
        [Key]
        public int project_phase_id { get; set; }
        [MaxLength(50)]
        public string project_phase_name { get; set; }
        [MaxLength(1000)]
        public string? project_phase_desc { get; set; }
    }
}
