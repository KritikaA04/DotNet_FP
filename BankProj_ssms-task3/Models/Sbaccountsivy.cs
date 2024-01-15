using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class Sbaccountsivy
{
    public int Acctno { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public decimal? Balance { get; set; }
}
