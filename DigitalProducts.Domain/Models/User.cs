﻿
namespace DigitalProducts.Domain.Models
{
    public class User
    {
        public enum Role
        {
            NormalUser,
            Admin
        }
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; } = new List<Product>();
        public Role role { get; set; }
    }
}
