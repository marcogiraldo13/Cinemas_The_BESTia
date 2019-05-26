using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CinemaViews.Views.Shared.Components.MovieGallery
{
    public class MovieGallery : ViewComponent
    {
        private readonly ICommand _executeBCommand;

        public MovieGallery(ICommand command)
        {
            _executeBCommand = command;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                Utilities.MoviesList = _executeBCommand.Execute();
                return View(Utilities.MoviesList);
            }
            catch (System.Exception)
            {
                return View(new List<Movie>());
                //throw;
            }
        }
    }
}
