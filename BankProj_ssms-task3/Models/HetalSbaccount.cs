using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class HetalSbaccount
{
    public int AccountNo { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public double Balance { get; set; }
}
