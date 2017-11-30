using ShoppingBasket.Domain.Interfaces;
using ShoppingBasket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        IOrder _order;

        public void SetOrder(IOrder order)
        {
            _order = order;
        }

        public void PrintReceiptDetails()
        {
            Console.Write($"{GetAllOrderLineItems()}\n" +
                $"Sales Taxes:{GetOrderSalesTax()}\n" +
                $"Total:{GetOrderTotal()}\n");
        }

        public string GetAllOrderLineItems()
        {
            return String.Join(
                "\n",
                _order.Products.Select(p => GetOrderLineItemFromProduct(p)));
        }

        public string GetOrderLineItemFromProduct(Product product)
        {
            return $"{product.Quantity} {product.Name}: {GetProductTaxedPrice(product)}";
        }

        public decimal GetOrderTotal()
        {
            return _order.Products.Sum(p => GetProductTaxedPrice(p));
        }

        public decimal GetOrderSalesTax()
        {
            return GetOrderTotal() 
                - _order.Products.Sum(p => p.Quantity * p.Price);
        }

        public decimal GetProductTaxedPrice(Product product)
        {
            return ApplyRoundingToAmount(
                GetProductSalesTax(product) 
                + (product.Price * product.Quantity),
                _order.TaxRules.CentsToRoundUpBy);
        }

        public decimal GetProductSalesTax(Product product)
        {
            return ApplyRoundingToAmount(
                (product.Price * product.Quantity) 
                * GetProductTaxRate(product),
                _order.TaxRules.CentsToRoundUpBy);
        }

        public decimal GetProductTaxRate(Product product)
        {
            return GetBasicTaxRate(product.Type)
                + GetImportTaxRate(product.IsImported);
        }

        public decimal GetBasicTaxRate(string productType)
        {
            return (_order.TaxRules.ExemptProductTypes.Contains(productType))
                ? 0.00M
                : _order.TaxRules.BasicRate;
        }

        public decimal GetImportTaxRate(bool isImported)
        {
            return (isImported)
                ? _order.TaxRules.ImportRate
                : 0.00M;
        }

        public decimal ApplyRoundingToAmount(decimal amount, Int16 centsToRoundUpBy)
        {
            amount = Math.Round(amount, 2); //this rounds up by one cents when third decimal figure is geater than 5, which is OK
            var secondDecimalDigit = GetSecondDecimalDigit(amount);

            if (secondDecimalDigit == 0)
                return amount;

            if (centsToRoundUpBy > secondDecimalDigit)
                return amount + ((centsToRoundUpBy - secondDecimalDigit) * 0.01M);

            return amount;
        }

        #region helpers
        private int GetSecondDecimalDigit(decimal amount)
        {
            var strAmount = amount.ToString();
            Int32.TryParse(strAmount.Substring(strAmount.Length - 1, 1), out int cents);
            return cents;
        }

        #endregion
    }
}
