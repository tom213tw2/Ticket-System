using System;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc;
using Ticket_System.Service;
using Ticket_System.ViewModel;

namespace Ticket_System.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult List()
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var id = new Guid(value);
            AccountService service = new AccountService(id);
            var data = service.GetList(null);
            ViewData["AccoutType"] = data.AccountType;
            return View(data);

        }

        public IActionResult Edit(Guid id)
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            AccountService service = new AccountService(_id);
            var data = service.GetDetail(id);
            ViewData["AccoutType"] = data.AccountType;
            return View(data.PageResult);
        }
        [HttpPost]
        public IActionResult Update(AccountModel.Result result)
        {
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            AccountService service = new AccountService(_id);
          
            if (ModelState.IsValid)
            {
                var data = service.UpdateData(result);
                return RedirectToAction("List", "Account");
            }
            else
            {
                return View("Edit",result);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            AccountModel.Result result = new AccountModel.Result();
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            AccountService service = new AccountService(_id);
            var data = service.GetInsert();
            ViewData["AccoutType"] = data.AccountType;
            return View("Edit", data.PageResult);

        }

        public IActionResult Delete(Guid id)
        {
            AccountModel.Result result = new AccountModel.Result();
            HttpContext.Session.TryGetValue("AccoutID", out byte[] value);
            var _id = new Guid(value);
            AccountService service = new AccountService(_id);
            service.DeleteData(id);
            return RedirectToAction("List", "Account");
        }

    }
}
