using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities.Settings
{
   public  class country_master:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(3)]
        public string country_code { get; set; }
        [MaxLength(50)]
        public string country_name { get; set; }
        public string content_code { get; set; }

        public content_master content { get; set; }
    }
}
