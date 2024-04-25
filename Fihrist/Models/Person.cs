using System;
using System.Collections.Generic;

namespace Fihrist.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public virtual ICollection<Info> Infos { get; set; } = new List<Info>();
}
