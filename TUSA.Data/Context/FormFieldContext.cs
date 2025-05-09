﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<forms_master> forms_master { get; set; }
        public DbSet<field_master> field_master { get; set; }
        public DbSet<form_type_master> form_type_master { get; set; }
        public DbSet<form_subtitle_master> form_subtitle_master { get; set; }
        public DbSet<form_subtitle_field_metrix> form_subtitle_field_metrix { get; set; }
        public DbSet<form_field_metrix> form_field_metrix { get; set; }
        public DbSet<dynamic_form_data> dynamic_form_data { get; set; }
        public DbSet<group_form_access_metrix> group_form_access_metrix { get; set; }

    }
}
