using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.QuickAndRecent.Request
{
  public   class form_details_request
    {
        public int form_id { get; set; }
        public string relavent_name { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
    }
}
