using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class field_master:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int field_id { get; set; }
        [MaxLength(30)]
        public string field_title { get; set; }
        [MaxLength(30)]
        public string field_data_type { get; set; }
        [MaxLength(30)]
        public string? field_length { get; set; }
        [MaxLength(3)]
        public string? is_dropdown { get; set; }
        [MaxLength(30)]
        public string? reference_if_dropdown { get; set; }
        [MaxLength(30)]
        public string? ref_filed_name { get; set; }
        [MaxLength(3)]
        public string is_active { get; set; }

    }
}
