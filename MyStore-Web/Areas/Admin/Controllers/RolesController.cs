using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore_Core.DTO.Role;
using MyStore_Core.Interfaces;
using MyStore_Data.Entities;
using MyStore_Web.Models.ViewModels.Role;

namespace MyStore_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly MyStoreDbContext _context;
        private readonly IRoleServices _roleServices;
        private readonly IMapper _mapper;

        public RolesController(MyStoreDbContext context, IRoleServices roleServices, IMapper mapper)
        {
            _context = context;
            _roleServices = roleServices;
            _mapper = mapper;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            var list = await _roleServices.GetallRole();
            var vm = _mapper.Map<List<RoleviewModel>>(list);
            return View(vm);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Roleid,RoleTitle,RoleName")] RoleCreatedto role)
        {
            var dto = _mapper.Map<RoleCreateDto>(role);
            await _roleServices.Creatrole(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleServices.GetoneRole(id);
            var vm = _mapper.Map<RoleviewModel>(role);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Roleid,RoleTitle,RoleName")] Role role)
        {
            var dto = _mapper.Map<RoleEditDto>(role);
            await _roleServices.EditRole(dto);
            return RedirectToAction(nameof(Index));

        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           var role=await _roleServices.GetoneRole(id);
            var vm = _mapper.Map<RoleviewModel>(role);
            return View(vm);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _roleServices.GetoneRole(id);
            var dto = _mapper.Map<RoleviewModel>(role);
            return View(dto);
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Roleid == id);
        }
    }
}
