using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CinemaViews.Views.Shared.Components.MovieGallery
{
    public class MovieGallery : ViewComponent
    {

        public MovieGallery()
        { }

        public IViewComponentResult Invoke()
        {
            try
            {
                WebClient client = new WebClient();
                var uri = "https://api.themoviedb.org/3/discover/movie?api_key=7453a15f4e0917e6a38e6cfce75ffd0c&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";
                var res = client.DownloadString(uri);
                var resFinal = res.Substring(63, res.Length - 64);
                var data = JsonConvert.DeserializeObject<List<Movie>>(resFinal);

                foreach (var item in data)
                {
                    item.Photo_Link = "https://image.tmdb.org/t/p/w185_and_h278_bestv2" + item.poster_path;
                }

                return View(data);
            }
            catch (System.Exception)
            {
                return View(new List<Movie>());
                //throw;
            }
        }
    }
}
