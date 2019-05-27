using CinemaViews.Models;
using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult SearchSeats(MovieViewModel model)
        {
            Utilities.BookingViewModelUtil = new BookingViewModel();
            Utilities.BookingViewModelUtil.BookingMovie = new Movie();
            Utilities.BookingViewModelUtil.SeatList = new List<Seat>();
            var allSeats = (List<Seat>)_executeBCommand.ExecuteSeats();
            Utilities.BookingViewModelUtil.BookingMovie = model.MovieSelect;
            Utilities.BookingViewModelUtil.FunctionMovie = model.Function;
            var seatbyFunction = (List<SeatxFunction>)_executeBCommand.ExecuteSeatsbyFunctionId(Convert.ToInt32(model.Function));

            var filterMovie = allSeats.Where(x => seatbyFunction.Any(y => y.seatId == x.Id && y.MovieId == model.MovieSelect.Id));
            foreach (var item in filterMovie)
            {
                allSeats.Where(x => x.Id == item.Id).FirstOrDefault().isavailable = true;
            }
            Utilities.BookingViewModelUtil.SeatList = allSeats;

            return RedirectToAction("Index", "Booking");
        }
    }
}