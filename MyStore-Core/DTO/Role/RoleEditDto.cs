using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.DTO.Role
{
    public class RoleEditDto
    {
        public int Roleid { get; set; }

        public string RoleTitle { get; set; } = null!;

        public string RoleName { get; set; } = null!;
    }
}
