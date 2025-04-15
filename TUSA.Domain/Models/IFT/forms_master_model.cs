using TUSA.Domain.Entities;

namespace TUSA.Domain.Models.IFT
{
    public class forms_master_model
    {
        public int form_id { get; set; }
        public module_master module { get; set; }
        public string form_name { get; set; }
        public string form_desc { get; set; }
        public string is_active { get; set; }
    }
}
