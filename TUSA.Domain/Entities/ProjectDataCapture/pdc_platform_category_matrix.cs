using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pdc_platform_category_matrix : BaseEntity
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  matrix_id{get;set;}
        [Key]
        public int platform_id { get; set; }
        [Key]
        public int category_id { get; set; }
        public int caotegory_order_no { get; set; }
        public bool is_active { get; set; }

    }
}
