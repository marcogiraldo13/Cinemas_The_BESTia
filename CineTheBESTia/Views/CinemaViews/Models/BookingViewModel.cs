using Domain;
using System;
using System.Collections.Generic;

namespace CinemaViews.Models
{
    public class BookingViewModel
    {
        public Movie BooingMovie { get; set; }
        public DateTime booking_date { get; set; }
        public List<Seat> SeatList { get; set; }
}
}
