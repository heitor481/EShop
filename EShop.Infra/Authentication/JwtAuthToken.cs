using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Infra.Authentication
{
    public class JwtAuthToken
    {
        public string Token { get; set; }

        public long ExpiredDate { get; set; }
    }
}
