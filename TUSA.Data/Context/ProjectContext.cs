using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Data
{
    public partial class TUSAContext
    {
        public DbSet<project_master> project_master { get; set; }
        public DbSet<group_project_access_metrix> group_project_access_metrix { get; set; }
        public DbSet<project_phase_master> project_phase_master { get; set; }
        public DbSet<project_scope_master> project_scope_master { get; set; }
        public DbSet<project_type_master> project_type_master { get; set; }
    }
}
