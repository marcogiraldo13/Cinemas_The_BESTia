using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public int vote_average { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
        public string image { get; set; }
    }
}
