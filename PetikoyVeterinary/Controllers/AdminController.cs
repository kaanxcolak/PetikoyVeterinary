using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetikoyVeterinary.Models;
using PetikoyVeterinaryBusinessLayer.EmailSenderBusiness;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.Constants;
using PetikoyVeterinaryEntityLayer.IdentityModels;
using PetikoyVeterinaryEntityLayer.ViewModels;
using PetikoyVeterinaryUI.Models;
using System.Security.Cryptography;
using System.Text;

namespace PetikoyVeterinaryUI.Controllers
{
    [Route("admin/[Action]/{id?}")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IContactClinicManager _contactClinicManager;
        private readonly IEmailSender _emailSender;

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IContactClinicManager contactClinicManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _contactClinicManager = contactClinicManager;
            _emailSender =  emailSender;
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
                TempData["LoggedInUsername"] = user.UserName; //username sayisal deger olarak geliyor!
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
                ModelState.AddModelError("", "Beklenmedik hata olustu!");
                return View(model);
            }
        }


        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        private string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }
        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }

        public IActionResult ContactClinic(ContactClinicVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Gerekli alanları lütfen doldurunuz!");
                    return View(model);
                }

                ContactClinicVM contact = new ContactClinicVM()
                {
                    PetInfo = model.PetInfo,
                    Name = model.Name,
                    SurName = model.SurName,
                    Phone=model.Phone,
                    Email = model.Email,
                    Question=model.Question
                };
                var result = _contactClinicManager.Add(contact);
                if (result.IsSuccess)
                {
                    To
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu " + ex.Message);
                return View(model);
            }
        }





    }
}
