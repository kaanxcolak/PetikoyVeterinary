using Microsoft.AspNetCore.Mvc;

namespace PetikoyVeterinaryUI.Components
{
    public class TopBarMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
