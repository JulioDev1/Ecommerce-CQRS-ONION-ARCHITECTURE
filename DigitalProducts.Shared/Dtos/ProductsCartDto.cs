namespace DigitalProducts.Shared.Dtos
{
    public class ProductsCartDto
    {
        public ProductsCartDto(string name, 
                               decimal price, 
                               string description, 
                               int quantity, 
                               long userId, 
                               long cartId, 
                               long creatorId, 
                               long productId)
        {
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
            UserId = userId;
            CartId = cartId;
            CreatorId = creatorId;
            ProductId = productId;
        }

        public string Name { get; set; } 
        public decimal Price { get; set; }
        public string Description { get; set; } 
        public int Quantity { get; set; }
        public long UserId { get; set; }
        public long CartId { get; set; }   
        public long CreatorId {  get; set; }   
        public long ProductId { get; set; }

    }
}
