using Domain;
using System;
using System.Collections.Generic;

namespace CinemaViews.Models
{
    public class BookingViewModel
    {
        public Movie BookingMovie { get; set; }
        public List<Seat> SeatList { get; set; }
        public string FunctionMovie { get; set; }
    }
}
