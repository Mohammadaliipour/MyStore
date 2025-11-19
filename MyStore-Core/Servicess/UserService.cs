using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO.User;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Servicess
{
    public class UserService:IUserService
    {
        private readonly MyStoreDbContext _db;
        private readonly IMapper _mapper;

        public UserService(MyStoreDbContext db, IMapper mapper)
        {
            _db = db; 
            _mapper = mapper;
   
        }
        public async Task Createuser(RegisterDto register) 
        {
            var user = _mapper.Map<User>(register);
            user.CreateDate = DateTime.Now;
            user.ActivitionCode =Guid.NewGuid().ToString();
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();

        }
    }
}
