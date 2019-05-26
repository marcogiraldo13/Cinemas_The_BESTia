using Domain;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ICommand
    {
        List<Movie> Execute();
    }
}
