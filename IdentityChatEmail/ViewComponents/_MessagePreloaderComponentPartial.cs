using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmail.ViewComponents
{
    public class _MessagePreloaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
