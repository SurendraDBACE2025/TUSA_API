using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class name_value_pair_model:BaseModel
    {
        public int field_id { get; set; }
        public string value { get; set; }
    }
}
