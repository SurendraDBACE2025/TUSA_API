using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TUSA.Domain.Entities
{
    [Table("user_login_fail")]
    public class user_login_fail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string user_name { get; set; }
        public DateTime loginat { get; set; }
        public string ip_address { get; set; }
    }
}
