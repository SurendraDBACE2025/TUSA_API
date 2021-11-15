using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class business_unit_master:BaseEntity
    {
        [Key]
        public int business_unit_id { get; set; }
        [MaxLength(50)]
        public string business_unit_name { get; set; }
        [MaxLength(1000)]
        public string? business_unit_desc { get; set; }

    }
}
