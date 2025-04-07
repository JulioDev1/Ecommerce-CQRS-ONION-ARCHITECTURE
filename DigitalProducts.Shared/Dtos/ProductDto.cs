namespace DigitalProducts.Shared.Dtos
{
    public class ProductDto
    {
        public ProductDto(string name, 
                          decimal price, 
                          string description,
                          long creatorId,
                          string pathImage, 
                          long typeProductId)
        { 
            Name = name;    
            Price = price;  
            Description = description;
            CreatorId = creatorId;
            PathImage = pathImage;
            TypeProductId = typeProductId;
        }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public long Quantity { get; set; }
        public long CreatorId { get; set; }
        public string PathImage { get; set; } = string.Empty;
        public long TypeProductId { get; set; }
    }
}
