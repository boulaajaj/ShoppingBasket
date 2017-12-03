using System.Collections.Generic;

namespace ShoppingBasket.Domain.Interfaces
{
    public interface ITaxRules
    {
        decimal BasicRate { get; set; }
        short CentsToRoundUpBy { get; set; }
        IEnumerable<string> ExemptProductTypes { get; set; }
        decimal ImportRate { get; set; }
    }
}