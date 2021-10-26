using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class group_master: AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int group_id { get; set; }
        [MaxLength(100)]
        public string group_name { get; set; }
        [MaxLength(100)]
        public string display_name { get; set; }
        public group_type_master group_type { get; set; }
        [MaxLength(1000)]
        public string group_desc { get; set; }
        [MaxLength(1000)]
        public string organization_name { get; set; }
        [MaxLength(1)]
        public string is_active { get; set; }
        [MaxLength(1)]
        public string is_deleted { get; set; }
    }
}
