using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaViews.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(Utilities.MoviesList.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}