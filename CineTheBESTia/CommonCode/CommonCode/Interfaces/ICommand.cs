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
        void ExecuteSaveBooking(Booking booking);
        void ExecuteSaveSeatxFunction(SeatxFunction seatxFunction);
        object ExecuteBooking();
    }
}
