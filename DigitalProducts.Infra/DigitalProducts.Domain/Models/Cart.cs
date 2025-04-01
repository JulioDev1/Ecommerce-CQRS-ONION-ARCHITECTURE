using System;
using System.Collections.Generic;

namespace DigitalProducts.Infra;

public partial class Cart
{
    public long Id { get; set; }

    public long Userid { get; set; }

    public long Productsid { get; set; }

    public DateTime? Createat { get; set; }

    public virtual ICollection<Cartsproduct> Cartsproducts { get; set; } = new List<Cartsproduct>();

    public virtual Product Products { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
