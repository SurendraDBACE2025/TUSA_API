using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TUSA.Domain.Entities;

namespace TUSA.Domain.Entities
{
    [Table("user_login_log")]
    public class user_login_log : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string user_email_id { get; set; }
        public DateTime loginat { get; set; }
        public string ip_address { get; set; }
    }
}
