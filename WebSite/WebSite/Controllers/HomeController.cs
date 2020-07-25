using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult Servis()
        {
            return View();
        }

        public IActionResult Galeri()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Iletisim(Mail m)
        {
            try
            {
               SmtpClient client =new SmtpClient("smtp.gmail.com",587);
               client.Credentials=new NetworkCredential("gulsenkeskiniletisimm@gmail.com","sanane.7_");
               client.EnableSsl = true;

               MailMessage mesaj=new MailMessage();
               mesaj.From=new MailAddress(m.Email, m.Ad +" "+ m.Soyad);
               mesaj.To.Add("gulsenkeskiniletisimm@gmail.com");
               mesaj.Subject = m.Konu;
               mesaj.Body = m.Mesaj;


               client.Send(mesaj);

               MailMessage geriBildirim =new MailMessage();
               geriBildirim.From=new MailAddress("gulsenkeskiniletisimm@gmail.com","Gülsen Keskin");
               geriBildirim.To.Add(m.Email);
               geriBildirim.Subject = m.Konu + " Konulu Mailiniz Hakkında";
               geriBildirim.Body ="Teşekkürler, mailiniz alınmıştır. En kısa sürede size geri dönüş yapılacaktır." +
                                  "\n\n Saygılamla." +
                                  "\n Gülsen Keskin";

                client.Send(geriBildirim);

                ViewBag.Succes = "Mail gönderme işlemi başarılı.";
                return View();
            }
            catch 
            {
                ViewBag.Error = "Mail gönderme işlemi başarısız.";
                return View();
            }
        }

    }
}
