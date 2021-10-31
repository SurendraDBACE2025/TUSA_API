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

        public DbSet<pdc_element_master> pdc_element_master { get; set; }
        public DbSet<pdc_header_data> pdc_header_data { get; set; }
        public DbSet<pdc_project_element_data> pdc_project_element_data { get; set; }
        public DbSet<pdc_category_master> pdc_category_master { get; set; }
       // public DbSet<pdc_platform_master> pdc_platform_master { get; set; }
        public DbSet<pdc_form_category_matrix> pdc_form_category_matrix { get; set; }

    }
}