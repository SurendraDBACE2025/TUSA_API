﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Domain.Entities
{
    public class user_group_metrix: BaseEntity
    {
        public user_master user { get; set; }
        public role_master role { get; set; }
        public group_master group { get; set; }
    }
}
