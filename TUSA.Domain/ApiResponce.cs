using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain
{
    public class ApiResponce
    {
        public bool Status { get; set; }
        public bool ErrorType { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponce<T>
    {
        public bool Status { get; set; }
        public bool ErrorType { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
