using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KritikaA
{
    public int EmpId { get; set; }

    public string? Ename { get; set; }

    public string? Edept { get; set; }

    public DateOnly? Edoj { get; set; }
}
