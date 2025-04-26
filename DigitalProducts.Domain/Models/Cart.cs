namespace DigitalProducts.Domain.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long UserId { get; set; }    
        public DateTime CreateAt { get; set; }
        public User? User { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>(); 
        public ICollection<CartsProduct>? CartProducts { get; set; } = new List<CartsProduct>();
    }
}
