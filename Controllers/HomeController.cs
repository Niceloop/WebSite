using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
 

namespace WebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View("Index2");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }


        // send email 
        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            // Get Post Params Here
            string name = collection["name"];
            string emailFrom = collection["email"];
            string phone = collection["phone"];
            string subject = collection["subject"];
            string message = collection["message"];


            if (name != null && emailFrom != null && subject != null && message != null)
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("do_not_reply@niceloop.com", "Niceloop1!"),
                    EnableSsl = true,
                })
                {
                    string htmlMessageBody = GenHtml(name, emailFrom, subject, message, phone);
                    MailMessage mm = new MailMessage(emailFrom, "rice.th@gmail.com, warut@riceengineer.com", "www.Niceloop.com "+ subject, htmlMessageBody);
                    mm.IsBodyHtml = true;
                   client.Send(mm);
                     
                }
                ViewBag.Message = "We have got your message. And we will response back soon.";
                return View();
            }
            else
            {
                //ViewBag.Message = "Something went wrong";
                return View();
            }
           
        }


        public ActionResult Breadcrumb(string sectionName)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.SectionName = sectionName;
            return PartialView("Partial/Breadcrumb");
        }

        public ActionResult TermConditions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Health()
        {
            
            return "I'm Good";
        }

        public PartialViewResult Bank()
        {
            return PartialView("Bank/Banks");
        }

        private string GenHtml(string name, string emailFrom, string subject, string message, string phone)
        {
            var messageConverted = message.Replace(Environment.NewLine, "<br />")
                                            .Replace("\r", "<br />")
                                            .Replace("\n", "<br />");

            string html = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><title>Email From www.Niceloop.com</title></head>";
            html += "<body>";
            html += "<div style='float: left'>";
            html += "<h3 style='display : block'>Name : "+ name+ " </h3>";
            html += "<h3 style='display : block'>Email : " + emailFrom + " </h3>";
            html += "<h3 style='display : block'>Phone : " + phone + " </h3>";
            html += "<h3 style='display : block'>Subject : " + subject + " </h3><br/>";
            html += "<p style='display : block'>Message : <br/>" + messageConverted + " </p>";
            html += "</div></body></html>";
            return html;
        }
    }
}
