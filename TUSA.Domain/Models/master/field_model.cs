using TUSA.Domain.Entities;

namespace TUSA.Domain.Models.master
{
    public class field_model : BaseEntity
    {     
        public int field_id { get; set; }
     
        public string field_title { get; set; }
     
        public string field_data_type { get; set; }
     
        public string? field_length { get; set; }
     
        public string? is_dropdown { get; set; }
     
        public string? reference_if_dropdown { get; set; }
     
        public string? ref_filed_name { get; set; }
     
        public string is_active { get; set; }

    }
}
