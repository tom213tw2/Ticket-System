using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Comman.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using Ticket_System.Service;

namespace Ticket_System.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var data = HttpContext.Session.Keys.Where(s => s.Contains("AccoutID"));
            if (data.Any())
            {
                base.OnActionExecuting(context);
            }
            else
            {
                Response.Redirect("/Login/Index");
            }
        }
    }
}
