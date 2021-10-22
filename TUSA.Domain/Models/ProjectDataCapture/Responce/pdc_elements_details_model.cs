using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_elements_details_model
    {
        public int MasterId { get; set; }
        public int HeaderId { get; set; }
        public int? Category { get; set; }
        public string CategoryName { get; set; }
        public string Phase { get; set; }
        public string Scope { get; set; }
        public bool? IsActive { get; set; }
        public string Units { get; set; }
        public string ServiceOrEquipment { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShareInTotal { get; set; }
        public string Commentary { get; set; }
        public string ModelOrType { get; set; }
        public decimal? Qty { get; set; }
        public decimal? TotalServiceHours { get; set; }
    }
}
