namespace DigitalProducts.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name {get; set;} = string.Empty;
        public decimal Price { get; set;}
        public string Description { get; set; } = string.Empty;
	    public long TypeProductId { get; set; }
        public required TypeProduct TypeProduct { get; set; }
        public long CreatorId { get; set; }
        public required User Creator { get; set; }
        public List<Cart>? Carts { get; } = [];
        public List<CartProduct>? CartProducts { get; set; } = [];
    }
}
