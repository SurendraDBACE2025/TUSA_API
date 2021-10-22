using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities.Settings
{
   public class project_type_master:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int project_type_id { get; set; }
        [MaxLength(50)]
        public string project_type_name { get; set; }
        [MaxLength(1000)]
        public string? project_type_desc { get; set; }
    }
}
