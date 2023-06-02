using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetikoyVeterinary.Models;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.Constants;
using PetikoyVeterinaryEntityLayer.IdentityModels;
using PetikoyVeterinaryUI.Models;

namespace PetikoyVeterinaryUI.Controllers
{
    [Route("admin/[Action]/{id?}")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //private readonly IClinicManager _clinicManager;
        //private readonly ICityManager _cityManager;
        //private readonly IDistrictManager _districtManager;        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // aynı username'den varsa hata versin
                var sameUser = _userManager.FindByNameAsync(model.Username).Result; // async bir metodun sonuna .Result yazarsak metod senkron çalışır
                if (sameUser != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı ismi sistemde mevcuttur! Farklı kullanıcı adı deneyiniz!");
                }


                sameUser = _userManager.FindByEmailAsync(model.Email).Result;
                if (sameUser != null)
                {
                    ModelState.AddModelError("", "Bu email ile sistemde mevcuttur! Farklı email deneyiniz!");
                }


                AppUser user = new AppUser()
                {
                    UserName = model.Username,
                    Name = model.Name,
                    Surname = model.Surname,
                    TcNo = model.TcNo,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    EmailConfirmed = true,
                };

                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {

                    var roleResult = _userManager.AddToRoleAsync(user, ConstantDatas.VETERINARYROLE).Result;
                    
                    if (roleResult.Succeeded)
                    {
                        TempData["RegisterSuccessMsg"] = "Kayıt başarılı!";
                    }
                    else
                    {
                        TempData["RegisterWarningMsg"] = "Kullanıcı oluştu! Ancak rolü atanamadı! Sistem yöneticisine ulaşarak rol ataması yapılmalıdır!";
                    }
                    return RedirectToAction("Login", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Ekleme başarısız!");
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(model);

            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = _userManager.FindByEmailAsync(model.UserNameOrEmail).Result;

                if (user == null)
                {
                    ModelState.AddModelError("", "Email ya da şifre hatalidir!");
                    return View(model);
                }
                var signinResult =
                 _signInManager.PasswordSignInAsync(user, model.Password, true, true).Result;
                TempData["LoggedInUsername"] = user.UserName; //username sayisal deger olarak geliyor.
                TempData["LoggedInNameSurname"] = $"{user.Name} {user.Surname}";

                if (!signinResult.Succeeded)
                {
                    ModelState.AddModelError("", "Giris BASARISIZDIR!");
                    return View(model);
                }
                if (_userManager.IsInRoleAsync(user, "ConstantDatas.CUSTOMERROLE").Result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (_userManager.IsInRoleAsync(user, "Admin").Result)
                {


                    return RedirectToAction("Dashboard", "Admin", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata olustu!");
                return View(model);
            }
        }



    }
}
