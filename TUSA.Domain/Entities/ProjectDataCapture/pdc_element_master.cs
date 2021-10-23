using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class pdc_element_master:BaseEntity
    {
        [Key, Column(Order = 0)]
        public int element_id { get; set; }
        [Key, Column(Order = 1)]
        public int category_id { get; set; }
        [MaxLength(100)]
        public string element_name { get; set; }
        public int element_order_no { get; set; }

        [MaxLength(200)]
        public string phase { get; set; }
        [MaxLength(100)]
        public string units { get; set; }
        [MaxLength(100)]
        public string service_or_equipment { get; set; }
        public bool is_active { get; set; }
    }
}
