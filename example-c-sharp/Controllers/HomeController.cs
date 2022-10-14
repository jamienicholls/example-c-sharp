using example_c_sharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace example_c_sharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageOne()
        {
            return View();
        }

        public IActionResult PageTwo()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(Models.ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // https://www.codeproject.com/tips/1081578/how-to-implement-contact-us-page-in-asp-net-mvc-as
                    //MailMessage msz = new MailMessage();
                    //msz.From = new MailAddress(vm.Email);//Email which you are getting 
                    //                                     //from contact us page 
                    //msz.To.Add("emailaddrss@gmail.com");//Where mail will be sent 
                    //msz.Subject = vm.Subject;
                    //msz.Body = vm.Message;
                    //SmtpClient smtp = new SmtpClient();

                    //smtp.Host = "smtp.gmail.com";

                    //smtp.Port = 587;

                    //smtp.Credentials = new System.Net.NetworkCredential
                    //("youremailid@gmail.com", "password");

                    //smtp.EnableSsl = true;

                    //smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = $"Hi {contactUs.Name}, Thank you for Contacting us. Your message about {contactUs.Subject} has been sent to one of our team and we will contact you at {contactUs.Email} as soon as we can.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
