using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore_Core.DTO.User;
using MyStore_Core.Interfaces;
using MyStore_Web.Models.ViewModels.User;

namespace MyStore_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;  
            _mapper = mapper;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName", "Email", "Password", "RePassword")] RegisterViewModel viewModel)
        {
            if (!await _userService.EmailExists(viewModel.Email)) 
            {
            var map=_mapper.Map<RegisterDto>(viewModel);
            await _userService.Createuser(map);
            return View("verifyemail",viewModel);
            
            }
            else {

                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت شده است!!!");
                return View(viewModel);
                
            
            }
        }
        public IActionResult verifyemail(RegisterViewModel viewModel)
        {
            return View(viewModel);
        }


    }
   
}
