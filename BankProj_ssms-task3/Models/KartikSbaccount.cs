using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KartikSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public double? CurrentBalance { get; set; }
}
