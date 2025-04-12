using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.IFT.Response
{
    public class FieldFormModuleMappingResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsErrorEncountered {  get; set; }
    }
}
