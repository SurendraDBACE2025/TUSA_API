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
        public DbSet<quick_access_screens> quick_access_screens { get; set; }
        public DbSet<recently_accessed_screens> recently_accessed_screens { get; set; }

    }
}
