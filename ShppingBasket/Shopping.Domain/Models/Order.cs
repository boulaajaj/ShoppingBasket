using ShoppingBasket.Domain.Interfaces;
using System.Collections.Generic;

namespace ShoppingBasket.Domain.Models
{
    public class Order : IOrder
    {
        public IEnumerable<IProduct> Products { get; set; }
        public ITaxRules TaxRules { get; set; }

    }
}
