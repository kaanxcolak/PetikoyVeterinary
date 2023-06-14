using Microsoft.AspNetCore.Mvc;
using PetikoyVeterinary.Models;
using PetikoyVeterinaryBusinessLayer.EmailSenderBusiness;
using PetikoyVeterinaryBusinessLayer.InterfacesOfManagers;
using PetikoyVeterinaryEntityLayer.ViewModels;
using System.Diagnostics;

namespace PetikoyVeterinary.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IContactClinicManager _contactClinicManager;
        private readonly IEmailSender _emailSender;

        public HomeController(IContactClinicManager contactClinicManager, IEmailSender emailSender)
        {
            _contactClinicManager = contactClinicManager;
            _emailSender = emailSender;
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
                    ModelState.AddModelError("", "Gerekli alanları lütfen doldurunuz!");
                    return View(model);
                }

                ContactClinicVM contact = new ContactClinicVM()
                {
                    PetInfo = model.PetInfo,
                    Name = model.Name,
                    SurName = model.SurName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Question = model.Question
                };
                var result = _contactClinicManager.Add(contact);
                if (result.IsSuccess)
                {
                    var email = new EmailMessage()
                    {
                        //To = "infoPetikoyVeterinary@gmail.com",
                        //Subject = $"Petikoy Veterinary Contact",
                        ////body içinde html yazılıyor
                        //Body = $"<html lang='tr'><head></head><body>" +
                        //$"Adım {contact.Name} {contact.SurName},<br/>" +
                        //$"Evcil hayvanım {contact.PetInfo} " +
                        //$"Evcil hayvanım ile alakalı sorun {contact.Question}" +
                        //$"{contact.Phone} numarasından veya {contact.Email} email adresinden benimle iletişim kurabilirsiniz!" +
                        //$"</body></hmtl>"
                        To = new string[] { contact.Email },
                        Subject = $"Petikoy Veterinary Contact",
                        //body içinde html yazılıyor
                        Body = $"<html lang='tr'><head></head><body>" +
                        $"Merhaba Sayın {contact.Name} {contact.SurName},<br/>" +
                        $"Bilgilerini tanımladığınız {contact.PetInfo} ile alakalı Sisteme kaydınız gerçekleşmiştir. " +
                        $"{contact.Phone} numarasından veya {contact.Email} adresinden sizinle yakın zamanda iletişime geçilecektir. Teşekkürler... " +
                        $"</body></hmtl>"
                    };
                    //sonra async'ye çevirelim
                    _emailSender.SendEmail(email);

                    // login sayfasına yönlendirilecek
                    TempData["RegisterSuccessMessage"] = $"{contact.Name} {contact.SurName} kaydınız gerçekleşti...";

                    return RedirectToAction("Home", "Index", new { email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu " + ex.Message);
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

        


    }
}