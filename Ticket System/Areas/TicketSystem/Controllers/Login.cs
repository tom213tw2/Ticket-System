using Microsoft.AspNetCore.Mvc;

namespace Ticket_System.Areas.TicketSystem.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
