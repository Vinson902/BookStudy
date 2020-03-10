using System;
using System.Linq;
using BookStudy.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookStudy.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MainPage()
        {
            return View("MainPage");
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "GoodMorning" : "GoodAfternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RspvForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RspvForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.addResponse(guestResponse);
                return View("ThankYou", guestResponse);
            } else
            {
                //there is a validation error
                return View();
            }

        }

        public ViewResult ListResponses()
        {
            return View(Repository.guests.Where(r => r.willAttend == true));
        }

    }
}
