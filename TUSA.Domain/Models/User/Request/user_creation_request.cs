using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.User
{
   public class user_creation_request
    {
      public List<user_craetion> users { get; set; }
    }
    public class user_craetion
    {
        public int group_Id { get; set; }
        public string email_Id { get; set; }
    }
}
