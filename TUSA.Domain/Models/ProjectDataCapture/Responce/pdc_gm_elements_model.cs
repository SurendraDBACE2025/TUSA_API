using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_gm_elements_model
    {
        public int masterId { get; set; }
        public Nullable<int> category { get; set; }
        public string phase { get; set; }
        public string scope { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string units { get; set; }
        public string serviceOrEquipment { get; set; }
    }
}
