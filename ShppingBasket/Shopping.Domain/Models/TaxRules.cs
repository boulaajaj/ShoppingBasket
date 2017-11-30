using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingBasket.Domain.Models
{
    public class TaxRules
    {
        public decimal BasicRate { get; set; }
        public IEnumerable<string> ExemptProductTypes { get; set; }
        public decimal ImportRate { get; set; }

        [Range(0, 9, ErrorMessage = "CentsToRoundUpBy cannot be greater than 9 or less than 0.")]
        public Int16 CentsToRoundUpBy { get; set; }
    }
}
