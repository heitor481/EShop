using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Infra.Authentication
{
    public class JwtOptions
    {
        public string Secret { get; set; }

        public int ExpireMinutes { get; set; }

        public string Issuer { get; set; }
    }
}
