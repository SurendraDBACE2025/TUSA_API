using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class BaseSearch
    { 
        public string Name { set; get; }
        private int idx = 0;
        public int Page { get { return idx; } set { idx = value; } }

        public int Size { get; set; }

        public string SortBy { get; set; }
        public bool IsDescend { get; set; }

        public int? RefId { get; set; }
    }
}
