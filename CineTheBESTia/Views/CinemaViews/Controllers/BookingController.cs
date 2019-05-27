using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaViews.Models;
using Microsoft.AspNetCore.Mvc;
using Common;
using Domain;

namespace CinemaViews.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View(Utilities.BookingViewModelUtil);
        }

        [HttpPost]
        public IActionResult PreBooking(BookingViewModel model)
        {








            return PartialView("Index", model);
        }
    }
}