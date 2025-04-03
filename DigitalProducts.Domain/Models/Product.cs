namespace DigitalProducts.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name {get; set;} = string.Empty;
        public decimal Price { get; set;}
        public string Description { get; set; } = string.Empty;
	    public long TypeProductId { get; set; }
        public long CreatorId { get; set; }
        public required TypeProduct TypeProduct { get; set; }
        public required User Creator { get; set; }
        public ICollection<Cart>? Carts { get; set; } = new List<Cart>();
        public ICollection<CartsProduct>? CartProducts { get; set; } = new List<CartsProduct>();
    }
}
