using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class form_type_master : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int form_type_id { get; set; }
        [MaxLength(100)]
        public string form_type_name { get; set; }
        [MaxLength(1000)]
        public string form_type_desc { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }
    }
}
