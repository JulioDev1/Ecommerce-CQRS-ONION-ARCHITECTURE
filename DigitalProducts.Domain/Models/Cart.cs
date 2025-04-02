namespace DigitalProducts.Domain.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }    
        public long ProductId { get; set; }
        public DateTime CreateAt { get; set; }
        public required User User { get; set; }
        public List<Product>? Products { get; set; } = [];
        public List<CartProduct>? CartProducts { get; } = [];
    }
}
