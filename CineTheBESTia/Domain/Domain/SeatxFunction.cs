using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SeatxFunction
    {
        public int Id { get; set; }
        public int functionId { get; set; }
        public int seatId { get; set; }
        public int movieId { get; set; }

        public Function function { get; set; }
        public Seat seat { get; set; }
    }
}
