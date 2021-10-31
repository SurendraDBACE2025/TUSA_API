using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
    public class forms_master:BaseEntity
    {
    [Key]
    public int form_id { get; set; }
    public module_master module_master { get; set; }
    [MaxLength(100)]
    public string form_name{ get; set; }
    [MaxLength(1000)]
    public string form_desc { get; set; }
    [MaxLength(3)]
    public string is_active { get; set; }

    }
}
