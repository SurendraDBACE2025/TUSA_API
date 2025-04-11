using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities.QuickAndRecent
{
  public  class form_details:AuditEntity
    {
        public int id { get; set; }
        public int form_id { get; set; }
        public string form_name  { get; set; }
        public string icon  { get; set; }
        public string link { get; set; }
    }
}
