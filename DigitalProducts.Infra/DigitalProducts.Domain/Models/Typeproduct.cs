using System;
using System.Collections.Generic;

namespace DigitalProducts.Infra;

public partial class Typeproduct
{
    public long Id { get; set; }

    public string Productype { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
