using Domain;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ICommand
    {
        object ExecuteFunctions();
        object ExecuteMovies();
        object ExecuteSeats();
    }
}
