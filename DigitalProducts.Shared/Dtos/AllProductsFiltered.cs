namespace DigitalProducts.Shared.Dtos
{
    public class AllProductsFiltered
    {
        public AllProductsFiltered(long id, 
            string name, 
            long quantity, 
            long creatorId, 
            DateTime createAt, 
            decimal price, 
            string description, 
            string productType)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            CreatorId = creatorId;
            CreateAt = createAt;
            Price = price;
            Description = description;
            ProductType = productType;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public long CreatorId { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
    }
}
