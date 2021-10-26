using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class name_value_pair:BaseEntity
    {
        public filed_master filed_master { get; set; }

        [MaxLength(100)]
        public string value { get; set; }

    }
}
