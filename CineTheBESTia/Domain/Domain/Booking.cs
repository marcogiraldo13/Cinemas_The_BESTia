using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int booking_cost { get; set; }
        public DateTime booking_date { get; set; }

        public Function functions { get; set; }
    }
}
