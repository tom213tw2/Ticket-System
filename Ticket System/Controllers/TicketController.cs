using System;
using Microsoft.AspNetCore.Mvc;
using Ticket_System.Service;
using Ticket_System.ViewModel;

namespace Ticket_System.Controllers
{
    public class TicketController : BaseController
    {
       
        [HttpGet]
        public IActionResult List()
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var id = new Guid(value);
            TicketService service = new TicketService(id);
            var data = service.GetList();
            ViewData["AccoutType"] = data.AccountType;
            return View(data);
        }

        public IActionResult Index(Guid id)
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            TicketService service = new TicketService(_id);
            var data = service.GetIndexData(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Index(TicketModel model)
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            TicketService service = new TicketService(_id);
            service.ResolveIssue(model.ResultFilter);
            return RedirectToAction("List", "Ticket");

        }
    }
}
