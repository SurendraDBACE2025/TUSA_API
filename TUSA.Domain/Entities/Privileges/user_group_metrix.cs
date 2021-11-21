using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Domain.Entities
{
    public class user_group_metrix : AuditEntity
    {
        [Key]
        public string user_master_Id { get; set; }
        public int role_Id { get; set; }
        public int group_Id { get; set; }
    }
}
