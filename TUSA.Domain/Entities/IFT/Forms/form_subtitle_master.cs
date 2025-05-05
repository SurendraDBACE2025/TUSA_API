using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class form_subtitle_master : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int form_subtitle_id { get; set; }
        [MaxLength(100)]
        public string subtitle_name { get; set; }
        [MaxLength(1000)]
        public string subtitle_desc { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }
    }
}
