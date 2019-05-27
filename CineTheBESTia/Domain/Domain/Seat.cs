using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Seat
    {
        public int Id { get; set; }
        public string seat_number { get; set; }
        [NotMapped]
        public bool isavailable { get; set; }

        public IEnumerable<SeatxFunction> seatxFunctions { get; set; }
    }
}
