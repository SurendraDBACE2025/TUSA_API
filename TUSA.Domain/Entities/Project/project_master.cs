using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class project_master:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int project_id { get; set; }
        [MaxLength(100)]
        public string project_name { get; set; }
        [MaxLength(1000)]
        public string? project_desc { get; set; }
        public project_type_master project_type { get; set; }
        public project_scope_master project_scope { get; set; }
        [MaxLength(100)]
        public string? project_size { get; set; }

        public int project_year { get; set; }
        public DateTime project_start_date { get; set; }
        public DateTime project_end_date { get; set; }
        public currency_master currency { get; set; }
        public country_master country { get; set; }
        public business_unit_master business_unit { get; set; }
        public site_master site { get; set; }

    }
}
