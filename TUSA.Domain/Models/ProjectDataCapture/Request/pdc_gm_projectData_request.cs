using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_gm_projectData_Request
    {
        public int matrixId { get; set; }
        public int headerId { get; set; }
        public decimal? price { get; set; }
        public decimal? shareInTotal { get; set; }
        public string commentary { get; set; }
        public string modelType { get; set; }
        public decimal? quantity { get; set; }
        public decimal? totalServiceHours { get; set; }
    }
}
