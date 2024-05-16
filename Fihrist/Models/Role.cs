using System;
using System.Collections.Generic;

namespace Fihrist.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IsActive { get; set; }

    public virtual ICollection<RolMember> RolMembers { get; set; } = new List<RolMember>();
}
