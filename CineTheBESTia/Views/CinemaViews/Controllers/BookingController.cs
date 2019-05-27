using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaViews.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(BookingViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("Create", model);
            //}

            //var path = $"wwwroot\\uploads\\{model.Photo.FileName}";

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    model.Photo.CopyTo(stream);
            //}

            //var photo = new Photo
            //{
            //    AlbumId = model.AlbumId,
            //    PhotoLink = $"/uploads/{model.Photo.FileName}"
            //};

            //_photoService.Create(photo);

            //return RedirectToAction("Index", new
            //{
            //    id = model.AlbumId
            //});
            return RedirectToAction("Index");
        }
    }
}