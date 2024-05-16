using System;
using System.Collections.Generic;

namespace Fihrist.Models;

public partial class Info
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int TypeId { get; set; }

    public string Value { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
