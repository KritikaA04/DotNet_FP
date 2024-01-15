using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SanskritiSbaccount
{
    public int Accno { get; set; }

    public string? Cname { get; set; }

    public string? CurrAddress { get; set; }

    public decimal? CurrBalance { get; set; }

    public virtual ICollection<SanskritiSbtransaction> SanskritiSbtransactions { get; set; } = new List<SanskritiSbtransaction>();
}
