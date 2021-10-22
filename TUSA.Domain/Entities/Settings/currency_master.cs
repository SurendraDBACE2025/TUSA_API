﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities.Settings
{
    public class currency_master:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(3)]
        public string currency_code { get; set; }
        [MaxLength(2)]
        public string? currency_symbol { get; set; }
        [MaxLength(255)]
        public string? currency_desc { get; set; }

        public string? country_code { get; set; }
        public country_master country { get; set; }
    }
}
