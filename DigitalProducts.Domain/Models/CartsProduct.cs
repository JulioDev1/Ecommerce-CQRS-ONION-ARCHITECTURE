﻿namespace DigitalProducts.Domain.Models
{
    public class CartsProduct
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
