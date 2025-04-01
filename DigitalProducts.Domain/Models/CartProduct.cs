using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalProducts.Domain.Models
{
    public class CartProduct
    {
        public long cartId { get; set; }
        public long productId { get; set; }
        public int quantity { get; set; }  
        public required Product product { get; set; }
        public required Cart cart { get; set; }
    }
}
