using System;
using System.Collections.Generic;

namespace DigitalProducts.Infra;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public long Typeproductid { get; set; }

    public long Creatorid { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Cartsproduct> Cartsproducts { get; set; } = new List<Cartsproduct>();

    public virtual User Creator { get; set; } = null!;

    public virtual Typeproduct Typeproduct { get; set; } = null!;
}
