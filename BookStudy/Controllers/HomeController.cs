using System;
using System.Linq;
using BookStudy.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookStudy.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult mainPage()
        {
            return View("MainPage");
        }

        public ViewResult index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "GoodMorning" : "GoodAfternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult rspvForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult rspvForm(GuestResponse guestResponse)
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

        public ViewResult listResponses()
        {
            return View(Repository.guests.Where(r => r.willAttend == true));
        }

    }
}
