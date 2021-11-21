using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public  class country_master:BaseEntity
    {
        [Key]
        [MaxLength(3)]
        public string country_code { get; set; }
        [MaxLength(50)]
        public string country_name { get; set; }
        [MaxLength(3)]
        public string hvec_flag { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }

        public continent_master continent { get; set; }
    }
}
