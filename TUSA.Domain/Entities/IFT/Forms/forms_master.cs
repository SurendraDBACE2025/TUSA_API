using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class forms_master : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int form_id { get; set; }
        [ForeignKey("module")]
        public int module_id { get; set; }
        public module_master module { get; set; }
        [MaxLength(100)]
        public string form_name { get; set; }
        [MaxLength(1000)]
        public string form_desc { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }
        [MaxLength(128)]
        public string icon { get; set; }
        [MaxLength(512)]
        public string link { get; set; }
        public int? form_type_id { get; set; }
    }
}
