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
        decimal GetOrderSalesTax();
        decimal GetOrderTotal();
        string GetOrderLineItemFromProduct(IProduct product);
        decimal GetProductSalesTax(IProduct product);
        decimal GetProductTaxedPrice(IProduct product);
        decimal GetProductTaxRate(IProduct product);
        void PrintReceiptDetails();
        ShoppingBasketService SetOrder(IOrder order);
    }
}