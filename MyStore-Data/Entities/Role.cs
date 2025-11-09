using System;
using System.Collections.Generic;

namespace MyStore_Data.Entities;

public partial class Role
{
    public int Roleid { get; set; }

    public string RoleTitle { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
