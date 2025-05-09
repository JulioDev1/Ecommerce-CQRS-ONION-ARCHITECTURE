﻿namespace DigitalProducts.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name {get; set;} = string.Empty;
        public decimal Price { get; set;}
        public string Description { get; set; } = string.Empty;
        public string PathImage { get; set; } = string.Empty;
        public long Quantity { get; set; }  
	    public required long TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public required long CreatorId { get; set; }
        public  User Creator { get; set; }
        public ICollection<Cart>? Carts { get; set; } = new List<Cart>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<CartsProduct>? CartProducts { get; set; } = new List<CartsProduct>();
    }
}
