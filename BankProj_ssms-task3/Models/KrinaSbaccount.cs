using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KrinaSbaccount
{
    public int Accno { get; set; }

    public string? Cname { get; set; }

    public string? CurrAddr { get; set; }

    public double? CurrBal { get; set; }

    public virtual ICollection<KrinaSbtransaction> KrinaSbtransactions { get; set; } = new List<KrinaSbtransaction>();
}
