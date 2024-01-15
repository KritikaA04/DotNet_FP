using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbAccountv
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public double? CurrentBalance { get; set; }

    public virtual ICollection<SbTransactionv> SbTransactionvs { get; set; } = new List<SbTransactionv>();
}
