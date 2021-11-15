
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class continent_master:BaseEntity
    {
        [Key]
        [MaxLength(2)]
        public string continent_code { get; set; }
        [MaxLength(50)]
        public string continent_name { get; set; }
        [MaxLength(1000)]
        public string? continent_desc { get; set; }
    }
}
