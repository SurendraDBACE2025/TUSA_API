using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pdc_header_data:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int header_Id { get; set; }
        [Key]
        public forms_master forms_master { get; set; }
        [MaxLength(100)]
        public string supplier_group{ get; set; }
        [MaxLength(100)]
        public string project_name { get; set; }
        public Nullable<int> project_year { get; set; }
        [MaxLength(100)]
        public string currency { get; set; }
        [MaxLength(100)]
        public string country { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> total_project_cost { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> year_1_onm_price { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> year_2_onm_price { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> installed_capacity_dc { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> installed_capacity_ac { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> year_1_yield { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> guaranteed_perf_ratio { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> minimum_perf_ratio { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> guaranteed_availability { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public Nullable<decimal> cod { get; set; }
        public bool is_active { get; set; }
        public bool is_deleted{ get; set; }


    }
}
