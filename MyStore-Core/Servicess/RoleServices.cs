using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO.Role;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace MyStore_Core.Servicess
{
    public class RoleServices : IRoleServices
    {
        private readonly MyStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public RoleServices(MyStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Creatrole(RoleCreateDto role)
        {
            var newrole = _mapper.Map<Role>(role);
            await _dbContext.AddAsync(newrole);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRole(int id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(s => s.Roleid == id);

            if (role != null)
            {

                _dbContext.Remove(role);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditRole(RoleEditDto editDto)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Roleid == editDto.Roleid);
            _mapper.Map(editDto, role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RoleDto>> GetallRole()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            var dto = _mapper.Map<List<RoleDto>>(roles);
            return dto;

        }
        public async Task<RoleDto> GetoneRole(int id)

        {
            var result = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Roleid == id);
            var dto = _mapper.Map<RoleDto>(result);
            return dto;

        }
    }
}
