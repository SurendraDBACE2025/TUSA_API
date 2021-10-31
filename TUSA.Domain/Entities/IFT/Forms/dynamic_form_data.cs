using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class dynamic_form_data : BaseEntity
    {
        [Key]
       public int module_id { get; set; }
        [MaxLength(3)]
        public string form_name   { get; set; }
        [Key]
        public int field_id { get; set; }
        [Key]
        public int Record_id { get; set; }
        [MaxLength(4000)]
        public string filed_value { get; set; }	

    }
}
