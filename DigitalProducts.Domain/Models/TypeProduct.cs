namespace DigitalProducts.Domain.Models
{
    public class TypeProduct
    {
        public long Id { get; set; }
        public string productType { get; set; } = string.Empty;
        public Product? Product { get; set; }

    }
}
