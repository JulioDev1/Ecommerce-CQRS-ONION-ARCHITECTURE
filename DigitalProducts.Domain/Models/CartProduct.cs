using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalProducts.Domain.Models
{
    public class CartProduct
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }  
        public required Product product { get; set; }
        public required Cart cart { get; set; }
    }
}
