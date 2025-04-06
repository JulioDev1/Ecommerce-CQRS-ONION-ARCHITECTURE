namespace DigitalProducts.Shared.Dtos
{
    public class AdminProductsDto
    {
        public AdminProductsDto(string name,
                                decimal price,
                                string description,
                                long creatorId,
                                string productType) 
        {

            Name = name;
            Price = price;
            Description = description;
            CreatorId = creatorId;  
            ProductType = productType;  
        }
        public string Name { get; set; }  
        public long CreatorId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }    
        public string ProductType { get; set; }
    }
}
