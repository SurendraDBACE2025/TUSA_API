﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class recently_accessed_screens:BaseEntity
    {
        public int user_email_id { get; set; }
        public user_master user_master { get; set; }
        public int form_id { get; set; }
        public forms_master forms_master { get; set; }
        public int form_list_order { get; set; }

    }
}
