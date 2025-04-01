using System;
using System.Collections.Generic;

namespace DigitalProducts.Infra;

public partial class Cartsproduct
{
    public long Cartid { get; set; }

    public long Productid { get; set; }

    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
