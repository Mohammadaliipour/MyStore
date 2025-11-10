using MyStore_Core.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Interfaces
{
    public interface IRoleServices

    {
        Task <List<RoleDto>> GetallRole();
        Task Creatrole (RoleCreateDto role);
        Task EditRole(RoleEditDto editDto);
        Task DeleteRole(int id);
        Task<RoleDto> GetoneRole(int id);

    }
}
