using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    //Error handling can be done as below as per - https://www.simple-talk.com/dotnet/asp-net/handling-errors-effectively-in-asp-net-mvc/
    //1) HandleError attribute configuration as action filter in Global.asax 
    //2) In Application Error method of Global.asax
    //void Application_Error(Object sender, EventArgs e)
    //{
    //    var exception = Server.GetLastError();
    //    if (exception == null)
    //        return;
    //    var mail = new MailMessage { From = new MailAddress("automated@contoso.com") };
    //    mail.To.Add(new MailAddress("administrator@contoso.com"));
    //    mail.Subject = "Site Error at " + DateTime.Now;
    //    mail.Body = "Error Description: " + exception.Message;
    //    var server = new SmtpClient { Host = "your.smtp.server" };
    //    server.Send(mail);
    //    // Clear the error
    //    Server.ClearError();
    //    // Redirect to a landing page
    //    Response.Redirect("home/landing");
    //}
    //3)Overriding Controller class - protected override void OnException(ExceptionContext filterContext)
    //{
    //    // Let other exceptions just go unhandled
    //    if (filterContext.Exception is InvalidOperationException)
    //    {
    //        // Default view is "error"
    //        filterContext.SwitchToErrorView();
    //    }
    //}
    //The SwitchToErrorView method is an extension method for the ExceptionContext class with the following signature:
    //public static void SwitchToErrorView(this ExceptionContext context, String view = "error", String master = "")

    //[HandleError(ExceptionType = typeof(ArgumentException), View = "generic")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}