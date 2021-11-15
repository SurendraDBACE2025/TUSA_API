using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pending_groups : BaseEntity
    {
        [Key]
        public int pending_group_ID { get; set; }
        public string group_Name { get; set; }
        public string organization_Name { get; set; }
        public string email_Id { get; set; }
        public string contact_First_Name { get; set; }
        public string contact_Last_Name { get; set; }
        // public bool same_For_User { get; set; }
        public bool is_activated { get; set; }
    }
    public class pending_groups_mails : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int pending_group_ID { get; set; }
        public pending_groups pending_Groups { get; set; }
        public Boolean mail_status { get; set; }
        public DateTime mail_sendedat { get; set; }
    }
}
