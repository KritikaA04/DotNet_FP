using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SuhasiniSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<SuhasiniSbtransaction> SuhasiniSbtransactions { get; set; } = new List<SuhasiniSbtransaction>();
}
