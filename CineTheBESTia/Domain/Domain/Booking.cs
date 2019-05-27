using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public double booking_cost { get; set; }
        public DateTime booking_date { get; set; }
        public int functionId { get; set; }
        public int movieId { get; set; }
        public bool isActive { get; set; }

        public Function functions { get; set; }
    }
}
