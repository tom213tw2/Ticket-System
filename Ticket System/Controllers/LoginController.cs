using System;
using System.Linq;
using Comman.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_System.Service;
using Ticket_System.ViewModel;

namespace Ticket_System.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            LoginModel model = new LoginModel();

            UserService service = new UserService(Guid.Parse("2781DB5F-14AD-48F1-8495-84CBFDC70120"));
            var data = service.GetAccountId();
            data.CopyPropertiesTo(model);

            return View(model);
        }
        [HttpPost]
        public IActionResult LoginUser(LoginModel login)
        {
            var data = HttpContext.Session.Keys.Where(s => s.Contains("AccoutID"));
            if (data.Any())
            {
                HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
                var id = new Guid(value);
            }
            UserService service = new UserService(login);
            (bool isSuccess, string Errormsg, Comman.Data.Model.DB.Login login) Status = service.LoginIsSuccess();
            if (!Status.isSuccess)
            {
                ViewData["ErrorMessage"] = Status.Errormsg;
                return View("Index");

            }
            else
            {
                HttpContext.Session.Clear();
                HttpContext.Session.Set("AccoutID", Status.login.Sno.ToByteArray());
                return RedirectToAction("List", "Account");
            }


         

        }
    }
}
