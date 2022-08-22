using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Infra.Events.Product
{
    public class ProductCreated
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
