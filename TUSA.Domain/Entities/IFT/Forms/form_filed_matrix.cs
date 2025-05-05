using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class form_field_metrix : BaseEntity
    {
        [Key]
        public int module_id { get; set; }
        [Key]
        public string form_name { get; set; }
        [Key]
        public string field_id { get; set; }
        public int form_subtitle_id { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }
        [MaxLength(3)]
        public string nullable { get; set; }
        public int field_order { get; set; }
        [MaxLength(3)]
        public string comments_available { get; set; }
        [MaxLength(255)]
        public string field_comment { get; set; }
        [MaxLength(30)]
        public string field_design_type { get; set; }
        [MaxLength(30)]
        public string field_validation{ get; set; }

    }
}
 