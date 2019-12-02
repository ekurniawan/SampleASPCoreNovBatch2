using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SampleASPCore.Controllers
{
    //[Route("company/[controller]/[action]")]
    public class HomeController : Controller
    {
        //
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.Username = username;
            return View();
        }

        public async Task<IActionResult> SendEmail()
        {
            var client = new SendGridClient("");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@actual-training.com",
                    "Administrator"),
                Subject = "Informasi",
                PlainTextContent = "Kirim email konfirmasi",
                HtmlContent = "Kirim email konfirmasi"
            };
            msg.AddTo(new EmailAddress("erick.kurniawan@gmail.com"));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);

            return Content("Kirim email");
        }

        public IActionResult LuasSegitiga(double alas,double tinggi){
            var hasil = 0.5 * alas * tinggi;
            ViewBag.Alas = alas;
            ViewBag.Tinggi = tinggi;
            ViewBag.Hasil = hasil;
            ViewBag.Username = "ekurniawan";
            return View("Index");
        }

        public IActionResult About(string nama,string alamat)
        {
            return Content($"Nama anda {nama} dan alamat {alamat}");
        }

        public IActionResult GetById(string id, string nama){
            return Content($"ID anda {id} dan nama {nama}");
        }

        public IActionResult GetData()
        {
            string[] arrName = new string[] { "CSharp", "Blazor", "Java", "React Redux", "FSharp" };
            return new JsonResult(arrName);
        }
    }
}