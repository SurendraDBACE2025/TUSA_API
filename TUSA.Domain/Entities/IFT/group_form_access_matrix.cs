using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class group_form_access_metrix:AuditEntity
    {
        [Key]
        public int form_id{ get; set; }
        public int group_id { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }

    }
}
