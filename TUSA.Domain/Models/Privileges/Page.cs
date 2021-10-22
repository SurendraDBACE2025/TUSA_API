using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class Page: BaseModel
    {
        public string Module { get; set; } 
        public int GroupId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; } 
        public int Privilege { get; set; }
    }
}
