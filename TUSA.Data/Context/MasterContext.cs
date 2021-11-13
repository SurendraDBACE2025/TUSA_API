using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities;

namespace TUSA.Data
{
    public partial class TUSAContext
    {
        public DbSet<group_type_master> group_type_master { get; set; }
        public DbSet<group_master> group_master { get; set; }
        public DbSet<country_master> country_master { get; set; }
        public DbSet<continent_master> continent_master { get; set; }
        public DbSet<currency_master> currency_master { get; set; }
        public DbSet<name_value_pair> name_value_pair { get; set; }

        public DbSet<business_unit_master> business_unit_master { get; set; }
        public DbSet<currency_conversion> currency_conversion { get; set; }

        public DbSet<site_master> site_master { get; set; }
        public DbSet<pending_groups> pending_groups { get; set; }

        public DbSet<pending_groups_mails> pending_groups_mails { get; set; }

    }
}
