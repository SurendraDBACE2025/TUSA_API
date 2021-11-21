using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class group_form_access_metrix:BaseEntity
    {
        [Key]
        public int form_id{ get; set; }
        [Key]
        public int group_id { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }

    }
}
