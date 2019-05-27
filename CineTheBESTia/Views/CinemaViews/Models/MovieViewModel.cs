using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaViews.Models
{
    public class MovieViewModel
    {
        public Movie MovieSelect { get; set; }
        public string Function { get; set; }
        public List<SelectListItem> FunctionList { get; set; }
    }
}
