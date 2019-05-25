using CinemaViews.Models;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;


namespace CinemaViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            WebClient client = new WebClient();
            var uri = "https://api.themoviedb.org/3/discover/movie?api_key=7453a15f4e0917e6a38e6cfce75ffd0c&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";
            var res = client.DownloadString(uri);
            var resFinal = res.Substring(63, res.Length - 64);
            var data = JsonConvert.DeserializeObject<Movie[]>(resFinal);


            return View(data);
        }

       

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
