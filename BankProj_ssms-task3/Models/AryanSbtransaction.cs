using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class AryanSbtransaction
{
    public int TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public virtual AryanSbaccount? AccountNumberNavigation { get; set; }
}
