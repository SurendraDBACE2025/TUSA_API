﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TUSA.API.Models
{
    public class Paginate<T>
    {
        public int From { get; set; }

        public int Index { get; set; }

        public int Size { get; set; }

        public int Count { get; set; }

        public int Pages { get; set; }
        public IEnumerable<T> Items { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }
    }
  
}
