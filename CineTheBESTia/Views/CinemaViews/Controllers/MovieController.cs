using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CinemaViews.Models;
using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaViews.Controllers
{
    public class MovieController : Controller
    {
        private readonly ICommand _executeBCommand;

        public MovieController(ICommand command)
        {
            _executeBCommand = command;
        }

        public IActionResult Index(int id)
        {
            return View(Utilities.MoviesList.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Insert(BookingViewModel model)
        {

            model.SeatList = (List<Seat>)_executeBCommand.ExecuteSeats();

            return View("../Booking/Index", model);
        }
    }
}