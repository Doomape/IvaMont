using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IvaMont.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Clients()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public static void SendMail(string subject, string body)
        {

            var fromAddress = new MailAddress("ilogicmk@gmail.com", "iLogic");
            string fromPassword = "ilogicmk2013";

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
                };

                System.Web.UI.WebControls.MailDefinition md = new System.Web.UI.WebControls.MailDefinition();
                md.From = "ilogicmk@gmail.com";
                md.IsBodyHtml = false;
                md.Subject = subject;
                System.Collections.Specialized.ListDictionary replacements = new System.Collections.Specialized.ListDictionary();
                MailMessage msg = md.CreateMailMessage("tomikrama@gmail.com,micevski.kosta@gmail.com", replacements, body, new System.Web.UI.Control());
                smtp.Send(msg);
            }
            catch
            {

            }
        }



        public JsonResult Sendform(string ime, string broj, string email, string poraka)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            if ((ime != "") && (email != "") && (poraka != ""))
            {
                string porakadoiLogic = "Name or Company: " + ime + "\n" + "Email: " + email + "\n" + "Number: " + broj + "\n" + "Message:" + "\n" + poraka;
                SendMail("Нова порака", porakadoiLogic);
                res.Add("msg", " Успешно испратена порака ");
            }
            else
            {
                res.Add("msg", " Неуспешно испратена порака ");
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
