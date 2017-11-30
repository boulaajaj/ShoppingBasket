using ShoppingBasket.Domain.Interfaces;
using ShoppingBasket.Domain.Models;

namespace ShoppingBasket.Services
{
    public interface IShoppingBasketService
    {
        decimal ApplyRoundingToAmount(decimal amount, short centsToRoundUpBy);
        string GetAllOrderLineItems();
        decimal GetBasicTaxRate(string productType);
        decimal GetImportTaxRate(bool isImported);
        string GetOrderLineItemFromProduct(Product product);
        decimal GetOrderSalesTax();
        decimal GetOrderTotal();
        decimal GetProductSalesTax(Product product);
        decimal GetProductTaxedPrice(Product product);
        decimal GetProductTaxRate(Product product);
        void PrintReceiptDetails();
        ShoppingBasketService SetOrder(IOrder order);
    }
}