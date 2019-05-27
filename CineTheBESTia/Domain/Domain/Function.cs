using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Function
    {
        public int Id { get; set; }
        public string details { get; set; }
        public bool isavailable { get; set; }
        public int cost { get; set; }

        public IEnumerable<SeatxFunction> seatxFunctions { get; set; }
        public IEnumerable<Booking> bookes { get; set; }
    }
}
