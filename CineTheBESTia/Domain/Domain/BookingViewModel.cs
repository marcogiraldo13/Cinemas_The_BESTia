using Domain;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class BookingViewModel
    {
        public Movie BookingMovie { get; set; }
        public List<Seat> SeatList { get; set; }
        public string FunctionMovie { get; set; }
        public string BookingCost { get; set; }
    }
}
