using Domain;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ICommand
    {
        object ExecuteFunctions();
        object ExecuteMovies();
        object ExecuteSeats();
        object ExecuteSeatsbyFunctionId(int idFunction);
        object ExecuteFunctionsbyId(int idFunction);
        object ExecuteSaveBooking(Booking booking);
        object ExecuteSaveSeatxFunction(SeatxFunction seatxFunction);
    }
}
