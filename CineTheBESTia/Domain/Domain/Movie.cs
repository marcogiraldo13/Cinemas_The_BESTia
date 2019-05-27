using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal vote_average { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
        public string image { get; set; }
        public bool video { get; set; }
        public int vote_count { get; set; }
        public string title { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal popularity { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string Photo_Link {  get; set; }
    }
}
