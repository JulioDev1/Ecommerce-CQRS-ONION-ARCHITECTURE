﻿namespace DigitalProducts.Domain.Models
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}
