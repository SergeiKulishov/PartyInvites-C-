using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning " : "Good Afternoon";

            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponce)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponce);

                return View("Thanks", guestResponce);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }


    }
}






