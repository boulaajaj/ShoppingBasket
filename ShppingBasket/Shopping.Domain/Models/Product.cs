using ShoppingBasket.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Domain.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }

    }
}
