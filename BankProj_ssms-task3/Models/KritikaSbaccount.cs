using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KritikaSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<KritikaSbtransaction> KritikaSbtransactions { get; set; } = new List<KritikaSbtransaction>();

}
