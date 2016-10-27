using System.Web.Mvc;
using LinhKienMayTinh.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Configuration;

namespace LinhKienMayTinh.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult LienHe()
        {
            var lh = new LienHe();
            return View(lh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> LienHe(LienHe model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _email = "luutrangminh@gmail.com";
                    var _epass = ConfigurationManager.AppSettings["EmailPassword"];
                    var _disName = model.UserName;
                    MailMessage myMessage = new MailMessage();
                    myMessage.To.Add(model.Email);
                    myMessage.From = new MailAddress(_email, _disName);
                    myMessage.Subject = model.ChuDe;
                    myMessage.Body = model.NoiDung;
                    myMessage.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.EnableSsl = true;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(_email, _epass);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                        await smtp.SendMailAsync(myMessage);
                    }

                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Sent");
            }
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}