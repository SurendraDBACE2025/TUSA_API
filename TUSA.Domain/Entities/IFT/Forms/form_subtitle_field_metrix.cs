using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class form_subtitle_field_metrix : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int form_subtitle_field_metrix_id { get; set; }
        [ForeignKey("subtitle")]
        public int form_subtitle_id { get; set; }
        public form_subtitle_master subtitle { get; set; }
        [ForeignKey("field")]
        public int field_id { get; set; }
        public field_master field { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }
    }
}
