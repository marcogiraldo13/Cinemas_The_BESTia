using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IActionResult GetAllBokkings()
        {
            try
            {
                var bookinAll = (List<Booking>)_executeBCommand.ExecuteBooking();
                return View("View", bookinAll.Where(x => x.isActive == true));
            }
            catch (Exception)
            {
                //throw;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult PreBooking(BookingViewModel model)
        {
            try
            {
                var functionBooking = _executeBCommand.ExecuteFunctionsbyId(Convert.ToInt32(model.FunctionMovie));
                var totalCost = (((Function)functionBooking).cost * (model.BookingMovie.vote_average / 10));
                model.BookingCost = (totalCost * model.SeatList.Where(x => x.isavailable == true).Count()).ToString();
                Utilities.BookingViewModelUtil.SeatList = model.SeatList;
            }
            catch (Exception)
            {
                //throw;
            }
            
            return View("FinishBooking", model);
        }


        [HttpPost]
        public IActionResult Booking(BookingViewModel model)
        {
            try
            {
                var bookingSave = new Booking();
                bookingSave.booking_cost = Convert.ToDouble(model.BookingCost);
                bookingSave.booking_date = DateTime.Now;
                bookingSave.functionId = Convert.ToInt32(model.FunctionMovie);
                bookingSave.movieId = model.BookingMovie.Id;
                bookingSave.isActive = true;
                _executeBCommand.ExecuteSaveBooking(bookingSave);


                foreach (var item in Utilities.BookingViewModelUtil.SeatList.Where(x => x.isavailable == true))
                {
                    var seatxFuntionSave = new SeatxFunction();
                    seatxFuntionSave.functionId = Convert.ToInt32(model.FunctionMovie);
                    seatxFuntionSave.seatId = item.Id;
                    seatxFuntionSave.movieId = model.BookingMovie.Id;
                    _executeBCommand.ExecuteSaveSeatxFunction(seatxFuntionSave);
                }
            }
            catch (Exception)
            {
                //throw;
            }
           
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Delete(int id)
        {
            try
            {
                _executeBCommand.ExecuteDeleteBooking(id);
            }
            catch (Exception)
            {
                //throw;
            }

            return RedirectToAction("Index", "Home");
        }

    }
}