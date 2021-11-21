using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class pdc_form_category_metrix: BaseEntity
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  matrix_id{get;set;}
        public forms_master form { get; set; }
        public pdc_category_master category { get; set; }
        public int caotegory_order_no { get; set; }
        public bool is_active { get; set; }

    }
}
