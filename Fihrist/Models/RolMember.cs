using System;
using System.Collections.Generic;

namespace Fihrist.Models;

public partial class RolMember
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
