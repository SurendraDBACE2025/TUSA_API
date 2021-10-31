using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class site_master:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int site_id { get; set; }
        [MaxLength(50)]
        public string site_name { get; set; }
        public country_master country_master { get; set; }
        [MaxLength(50)]
        public string? langitude { get; set; }
        [MaxLength(50)]
        public string? latitude { get; set; }
        [MaxLength(1000)]
        public string? site_desc { get; set; }	

    }
}
