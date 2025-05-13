using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmail.ViewComponents
{
    public class _MessageSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
