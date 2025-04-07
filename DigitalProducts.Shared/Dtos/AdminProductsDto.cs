namespace DigitalProducts.Shared.Dtos
{
    public class AdminProductsDto
    {
        public AdminProductsDto(
                                long id,
                                long quantity,
                                string name,
                                decimal price,
                                string description,
                                long creatorId,
                                string productType,
                                string createAt)
        {

            Id = id;
            Quantity = quantity;
            Name = name;
            Price = price;
            Description = description;
            CreatorId = creatorId;
            ProductType = productType;
            CreateAt = createAt;
        }
        public long Id { get; set; }
        public string Name { get; set; }  
        public long Quantity { get; set; }
        public long CreatorId { get; set; }
        public string CreateAt { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }    
        public string ProductType { get; set; }
    }
}
