using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbtransactionsJivanshu
{
    public int Transactionsid { get; set; }

    public DateTime? Transactiondate { get; set; }

    public int? Accountnumber { get; set; }

    public decimal? Amount { get; set; }

    public string? Transactiontype { get; set; }

    public virtual SbaccountJivanshu? AccountnumberNavigation { get; set; }
}
