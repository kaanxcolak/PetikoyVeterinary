using Microsoft.AspNetCore.Mvc;

namespace PetikoyVeterinaryUI.Components
{
    public class AdminSideBarMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();

        }
    }
}
