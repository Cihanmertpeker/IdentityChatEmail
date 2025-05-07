using IdentityChatEmail.Context;
using IdentityChatEmail.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.email = values.Email;
            ViewBag.nameSurname = values.Name + " " + values.Surname;

            var values2 = _context.Messages.Where(x=>x.ReceiverEmail==values.Email).ToList();

            return View(values2);
        }

        public IActionResult Sendbox()
        {
            return View();
        }

        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Sendbox");
        }
    }
}
