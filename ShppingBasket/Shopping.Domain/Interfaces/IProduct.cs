namespace ShoppingBasket.Domain.Interfaces
{
    public interface IProduct
    {
        bool IsImported { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        string Type { get; set; }
    }
}