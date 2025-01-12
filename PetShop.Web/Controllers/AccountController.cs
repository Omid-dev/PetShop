using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;
using PetShop.Domain.ViewModels;
using PetShop.Infra.Data.Context;
using System.Security.Claims;

namespace PetShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IUserDetailServices _userDetailServices;
        private readonly PetShopContext context;

        public AccountController(IUserServices userServices, IUserDetailServices userDetailServices)
        {
            this._userServices = userServices;
            this._userDetailServices = userDetailServices;
            this.context = context;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var user = _userServices.GetByEmail(login.Email);
            if (!ModelState.IsValid)
                return View(login);
            if (!await _userServices.EmailIsExist(login.Email))
            {
                ModelState.AddModelError("Email", "حساب کاربری یافت نشد");
                return View(login);
            }
            if (!HasherPassword.VerifyHashedPassword(user.Password, login.Password))
            {
                ModelState.AddModelError("Email", "حساب کاربری یافت نشد");
                return View(login);
            }

            var claim = new List<Claim>();
            claim.Add(new Claim(ClaimTypes.Name, user.Name));
            claim.Add(new Claim("id", user.Id.ToString()));
            claim.Add(new Claim("IsAdmin", user.IsAdmin.ToString()));
            claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext?.SignInAsync(principal, properties);

            return Redirect("/");
        }

        [Route("/LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            #region Validation

            if (!ModelState.IsValid)
                return View(viewModel);
            if (await _userServices.EmailIsExist(viewModel.Email))
            {
                ModelState.AddModelError("Email", "این ایمیل قبلا ثبت نام کرده است");
                return View(viewModel);
            }
            if (await _userServices.PhoneNumberIsExist(viewModel.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "این موبایل قبلا ثبت نام کرده است");
                return View(viewModel);
            }

            #endregion Validation

            await _userServices.InseretAsync(viewModel);
            return Redirect("/");
        }

        [HttpGet("/Denied")]
        public IActionResult Denied()
        {
            return View();
        }

        public async Task<IActionResult> EditAccount()
        {
            var user = await _userServices.GetByIdAsync(User.GetUserId());
            var userDetail = await _userDetailServices.GetByUserId(User.GetUserId());
            DetailUserViewModel detailUser = new DetailUserViewModel()
            {
                Email = user.Email,
                Family = user.Family,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id,
            };
            if (userDetail != null)
            {
                detailUser.State = userDetail?.State;
                detailUser.Street = userDetail?.Street;
                detailUser.UserId = userDetail.UserId;
                detailUser.Zip_Code = userDetail?.Zip_Code;
                detailUser.IdDetail = userDetail.Id;
                detailUser.ApartmentName = userDetail?.ApartmentName;
                detailUser.City = userDetail?.City;
            }

            return View(detailUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(DetailUserViewModel detailUser)
        {
            if (!ModelState.IsValid)
                return View(detailUser);
            await _userServices.UpdateWithViewModel(detailUser);
            await _userServices.Save();
            await _userDetailServices.UpdateWithViewModel(detailUser);
            await _userDetailServices.Save();

            return Redirect("/");
        }
    }
}