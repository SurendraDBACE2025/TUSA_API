using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class user_type_master: AuditEntity
    {
        [Key]
        public int user_type_id { get; set; }

        [MaxLength(100)]
        public string user_type_name { get; set; }
    }
}
