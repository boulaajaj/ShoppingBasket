using System;
using System.Collections.Generic;

namespace ShoppingBasket.Domain.Models
{
    public class TaxRules
    {
        public decimal BasicRate { get; set; }
        public IEnumerable<string> ExemptProductTypes { get; set; }
        public decimal ImportRate { get; set; }
        public Int16 CentsToRoundUpBy { get; set; }
    }
}
