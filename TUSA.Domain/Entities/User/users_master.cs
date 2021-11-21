using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUSA.Domain.Entities
{
    public class user_master : AuditEntity
    { 
        [Key]
        [MaxLength(128)]
        public string user_master_id { get; set; }
        [MaxLength(30)]
        public string first_name { get; set; }
        [MaxLength(30)]
        public string last_name { get; set; }
        [MaxLength(50)]
        public string contact_number { get; set; }

        [MaxLength(255)]
        public string password { get; set; }
        public user_type_master user_type { get; set; }
        public DateTime last_login_time { get; set; }
        public DateTime password_changed_date { get; set; }
        [MaxLength(255)]
        public string activation_code { get; set; }
        [MaxLength(255)]
        public string reset_password_date { get; set; }
        public DateTime last_reset_attempt_time { get; set; }
        public string refresh_token { get; set; }
        public DateTime refresh_token_expiryat { get; set; }
        [MaxLength(1)]
        public string is_activated { get; set; }
        [MaxLength(1)]
        public string is_active { get; set; }
        [MaxLength(1)]
        public string is_deleted { get; set; }
    }
}
