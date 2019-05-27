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
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var movieViewModel = new MovieViewModel();
            movieViewModel.MovieSelect = Utilities.MoviesList.Where(x => x.Id == id).FirstOrDefault();
            var functionList = (List<Function>)_executeBCommand.ExecuteFunctions();
            movieViewModel.FunctionList = new List<SelectListItem>();
            foreach (var item in functionList)
            {
                movieViewModel.FunctionList.Add(new SelectListItem
                {
                    Text = item.details,
                    Value = item.Id.ToString(),
                });
            }

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Insert(MovieViewModel model)
        {
            var bookingModel = new BookingViewModel();
            bookingModel.SeatList = (List<Seat>)_executeBCommand.ExecuteSeats();
            bookingModel.BookingMovie = model.MovieSelect;
            bookingModel.FunctionMovie = model.Function;

            return View("../Booking/Index", bookingModel);
        }
    }
}