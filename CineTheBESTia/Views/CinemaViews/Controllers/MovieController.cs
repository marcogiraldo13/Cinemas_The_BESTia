using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaViews.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(int id)
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

            return View(data.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}