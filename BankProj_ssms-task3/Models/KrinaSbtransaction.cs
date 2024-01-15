using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KrinaSbtransaction
{
    public int Transid { get; set; }

    public DateTime? Transdate { get; set; }

    public int? Accno { get; set; }

    public int? Amt { get; set; }

    public string? Tt { get; set; }

    public virtual KrinaSbaccount? AccnoNavigation { get; set; }
}
