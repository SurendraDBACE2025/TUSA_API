using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities.Settings
{
    public class currency_conversion:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int exchange_rate_id { get; set; }
        [MaxLength(3)]
        public string from_currency { get; set; }
        [MaxLength(3)]
        public string to_currency { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal rate { get; set; }
        [MaxLength(1)]
        public string? is_active { get; set; }
    }
}
