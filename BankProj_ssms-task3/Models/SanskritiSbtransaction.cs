using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SanskritiSbtransaction
{
    public int Transid { get; set; }

    public DateOnly? Transdate { get; set; }

    public int? Accno { get; set; }

    public decimal? Amt { get; set; }

    public string? Transtype { get; set; }

    public virtual SanskritiSbaccount? AccnoNavigation { get; set; }
}
