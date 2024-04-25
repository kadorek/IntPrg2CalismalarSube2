using System;
using System.Collections.Generic;

namespace Fihrist.Models;

public partial class Type
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Info> Infos { get; set; } = new List<Info>();
}
