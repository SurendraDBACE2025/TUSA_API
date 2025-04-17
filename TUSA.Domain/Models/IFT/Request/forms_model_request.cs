using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.IFT.Request
{
    public class forms_assign_model_request
    {
        public int form_id { get; set; }

        public int group_id { get; set; }
        public string Action { get; set; }
    }
}
