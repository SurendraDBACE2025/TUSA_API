using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Domain.Models
{
    public class TokenApiModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
