using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO.User;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            user.Email =register.Email.Trim().ToLower();
            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user,user.Email);
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();

        }


         public async Task<bool> EmailExists(string email) 
        {
        
        return await _db.Users.AnyAsync(u => u.Email == email.Trim().ToLower());
        }
    }
}
