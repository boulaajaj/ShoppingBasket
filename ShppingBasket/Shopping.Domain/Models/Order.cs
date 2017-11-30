using ShoppingBasket.Domain.Interfaces;
using System.Collections.Generic;

namespace ShoppingBasket.Domain.Models
{
    public class Order : IOrder
    {
        public IEnumerable<Product> Products { get; set; }
        public TaxRules TaxRules { get; set; }

    }
}
