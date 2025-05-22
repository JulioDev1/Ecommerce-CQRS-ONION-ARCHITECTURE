namespace DigitalProducts.Shared.Dtos
{
    public class FilterProductDto
    {
        public decimal? maxPrice { get; set; }
        public decimal? minPrice { get; set; }
        public string typeProduct { get; set; } = string.Empty;
    }
}
