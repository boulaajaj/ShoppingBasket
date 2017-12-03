using ShoppingBasket.Domain.Models;
using System.Collections.Generic;

namespace ShoppingBasket.Domain.Interfaces
{
    public interface IOrder
    {
        IEnumerable<IProduct> Products { get; set; }
        ITaxRules TaxRules { get; set; }
    }
}
