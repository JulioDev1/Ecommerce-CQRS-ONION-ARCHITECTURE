namespace DigitalProducts.Domain.Models
{
    public class CartProduct
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }  
        public required Product Products { get; set; }
        public required Cart Carts { get; set; }
    }
}
