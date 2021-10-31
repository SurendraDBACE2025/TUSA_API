﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pdc_project_element_data:BaseEntity
    {
        public int matrix_id { get; set; }
        public int header_id{ get; set; }
        [MaxLength(200)]
        public string modal_type { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> quantity { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> total_service_hours { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> unit_cost { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> share_in_total { get; set; }
        [MaxLength(4000)]
        public string scope_commmentary { get; set; }
    }
}
