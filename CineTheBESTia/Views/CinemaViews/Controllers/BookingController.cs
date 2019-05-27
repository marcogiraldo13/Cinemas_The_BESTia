using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CinemaViews.Controllers
{
    public class BookingController : Controller
    {
        private readonly ICommand _executeBCommand;

        public BookingController(ICommand command)
        {
            _executeBCommand = command;
        }

        public IActionResult Index()
        {
            return View(Utilities.BookingViewModelUtil);
        }

        [HttpPost]
        public IActionResult PreBooking(BookingViewModel model)
        {
            var functionBooking = _executeBCommand.ExecuteFunctionsbyId(Convert.ToInt32(model.FunctionMovie));
            var totalCost = (((Function)functionBooking).cost * (model.BookingMovie.vote_average/10));
            model.BookingCost = (totalCost * model.SeatList.Where(x => x.isavailable == true).Count()).ToString();

            return View("FinishBooking", model);
        }


        [HttpPost]
        public IActionResult Booking(BookingViewModel model)
        {

            var bookingSave = new Booking();
            bookingSave.booking_cost = Convert.ToInt32(model.BookingCost);
            bookingSave.booking_date = DateTime.Now;
            bookingSave.functionId = Convert.ToInt32(model.FunctionMovie);
            bookingSave.movieId = model.BookingMovie.Id;
            _executeBCommand.ExecuteSaveBooking(bookingSave);


            foreach (var item in model.SeatList.Where(x => x.isavailable == true))
            {
                var seatxFuntionSave = new SeatxFunction();
                seatxFuntionSave.functionId = Convert.ToInt32(model.FunctionMovie);
                seatxFuntionSave.seatId = item.Id;
                seatxFuntionSave.movieId = model.BookingMovie.Id;
                _executeBCommand.ExecuteSaveSeatxFunction(seatxFuntionSave);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}