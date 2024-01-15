using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SuhasiniSbtransaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public virtual SuhasiniSbaccount? AccountNumberNavigation { get; set; }
}
