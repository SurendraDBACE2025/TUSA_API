using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pdc_gm_project_data:BaseEntity
    {
        [Key]
        public int masterId { get; set; }
        public int headerId { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> share_in_Total { get; set; }
        public string scope_commmentary { get; set; }
        public string modeltype { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> totalServiceHours { get; set; }
    }
}
