using ShoppingBasket.Domain.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Domain.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Product> Products { get; set; }
        TaxRules TaxRules { get; set; }
    }
}
