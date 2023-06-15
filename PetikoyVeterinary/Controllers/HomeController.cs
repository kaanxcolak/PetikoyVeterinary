using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetikoyVeterinary.Models;
using PetikoyVeterinaryBusinessLayer.EmailSenderBusiness;
using PetikoyVeterinaryBusinessLayer.ImplementationsOfManagers;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.IdentityModels;
using PetikoyVeterinaryEntityLayer.ViewModels;
using System.Diagnostics;

namespace PetikoyVeterinary.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IContactClinicManager _contactClinicManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public HomeController(UserManager<AppUser> userManager, IContactClinicManager contactClinicManager, IEmailSender emailSender, IMapper mapper)
        {
            _userManager = userManager;
            _contactClinicManager = contactClinicManager;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult ContactClinic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactClinic(ContactClinicVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Bilgileri düzgün giriniz");
                    return View(model);
                }


                ContactClinicVM contact = new ContactClinicVM()
                {
                    CreatedDate = DateTime.Now,
                    PetInfo = model.PetInfo,
                    Name = model.Name,
                    SurName = model.SurName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Question = model.Question,
                };

                if (_contactClinicManager.Add(contact).IsSuccess)
                {
                    TempData["ContactSuccessMsg"] = "Sorunuz kliniğe iletildi!";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Soruyu kaydetme başarısız! Tekrar deneyiniz!");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult About() { return View(); }

        [HttpPost]
        public IActionResult About(PetInfoBlogVM model)
        {
            //Buraya sonradan bilgilerin girildiği yapı kurulacak
            //Müşterilerin kendi hayvanları hakkında mı yazması yoksa veterinerin mi yazması hakkında bilgi alacaksın
            return View(model);
        }

        //[HttpGet]
        //public IActionResult CustomerInformations() { return View(); }
        //[HttpPost]
        //public IActionResult CustomerInformations(ContactClinicVM model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            ModelState.AddModelError("", "Bilgileri düzgün giriniz");
        //            return View(model);
        //        }

        //        var sameContact = _contactClinicManager.GetByConditions(x => x.Name == model.Name && x.SurName == model.SurName).Data;


        //        if (sameContact != null)
        //        {
        //            ModelState.AddModelError("", "Randevu var!");
        //            return View(model);
        //        }

        //        // müşteriden var mı?
        //        //yoksa ekle
        //        var customer = _userManager.FindByEmailAsync(model.Email).Result;

        //        if (customer == null)
        //        {

        //            AppUser user = new AppUser()
        //            {
        //                Name = model.Name,
        //                Surname = model.SurName,
        //                //TcNo = model.TcNo,
        //                Email = model.Email,
        //                PhoneNumber = model.Phone,
        //            };

        //            var result = _userManager.CreateAsync(user, model.Phone).Result;
        //            if (result.Succeeded)
        //            {
        //                var roleResult = _userManager.AddToRoleAsync(user, "Customer").Result;
        //            }
        //        }
        //        ContactClinicVM contact = new ContactClinicVM()
        //        {
        //            PetInfo = model.PetInfo,
        //            Name = model.Name,
        //            SurName = model.SurName,
        //            Phone = model.Phone,
        //            Email = model.Email,
        //            Question = model.Question,
        //        };

        //        if (_contactClinicManager.Add(_mapper.Map<ContactClinicVM>(contact)).IsSuccess)
        //        {
        //            TempData["ContactSuccessMsg"] = "Kayıt başarılı!";
        //            return RedirectToAction("CustomerInformations", "home");

        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Kullanıcı oluştu! Ancak rolü atanamadı! Sistem yöneticisine ulaşarak rol ataması yapılmalıdır!");
        //            return View(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(model);
        //    }

        //}

    }
}
