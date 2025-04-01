using System.Runtime.InteropServices;

namespace DigitalProducts.Domain.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }    
        public long ProductId { get; set; }
        public DateTime CreateAt { get; set; }
        public required User User { get; set; }
    }
}
