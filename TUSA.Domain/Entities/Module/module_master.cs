using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class module_master:BaseEntity
    {
        [Key]
        public int module_id { get; set; }
        [MaxLength(50)]
        public string module_name { get; set; }
        [MaxLength(1000)]
        public string module_desc { get; set; }

    }
}
