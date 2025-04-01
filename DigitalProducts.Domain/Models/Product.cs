using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Reflection;

namespace DigitalProducts.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name {get; set;} = string.Empty;
        public decimal Price { get; set;}
        public string Description { get; set; } = string.Empty;
	    public long TypeProductId { get; set; }
        public long CreatorId { get; set; }
        public required TypeProduct TypeProduct { get; set; }
        public required User Creator { get; set; }
    }
}
