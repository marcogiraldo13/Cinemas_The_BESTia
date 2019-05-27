using Common.Interfaces;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Implementations
{
    public class TheMovieDBCommand : ICommand
    {
        public object ExecuteFunctions()
        {
            try
            {
                WebClient client = new WebClient();
                var uri = "http://localhost:63845/api/Functions";
                var res = client.DownloadString(uri);
                var response = JsonConvert.DeserializeObject<List<Function>>(res);

                return response;
            }
            catch (Exception)
            {
                return new List<Movie>();
                //throw;
            }
        }

        public object ExecuteMovies()
        {
            try
            {
                WebClient client = new WebClient();
                var uri = "https://api.themoviedb.org/3/discover/movie?api_key=7453a15f4e0917e6a38e6cfce75ffd0c&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";
                var res = client.DownloadString(uri);
                var result = res.Substring(63, res.Length - 64);
                var response = JsonConvert.DeserializeObject<List<Movie>>(result);

                foreach (var item in response)
                {
                    item.Photo_Link = "https://image.tmdb.org/t/p/w185_and_h278_bestv2" + item.poster_path;
                }
                return response;
            }
            catch (Exception)
            {
                return new List<Movie>();
                //throw;
            }
           
        }

        public object ExecuteSeats()
        {
            try
            {
                WebClient client = new WebClient();
                var uri = "http://localhost:63845/api/Seats";
                var res = client.DownloadString(uri);
                var response = JsonConvert.DeserializeObject<List<Seat>>(res);

                return response;
            }
            catch (Exception)
            {
                return new List<Movie>();
                //throw;
            }
        }

        public object ExecuteSeatsbyFunctionId(int idFunction)
        {
            try
            {
                WebClient client = new WebClient();
                var uri = string.Format("http://localhost:63845/api/SeatxFunctions/GetFunctionbyId/{0}", idFunction);
                var res = client.DownloadString(uri);
                var response = JsonConvert.DeserializeObject<List<SeatxFunction>>(res);

                return response;
            }
            catch (Exception ex)
            {
                return new List<SeatxFunction>();
                //throw;
            }
        }

        public object ExecuteFunctionsbyId(int idFunction)
        {
            try
            {
                WebClient client = new WebClient();
                var uri = string.Format("http://localhost:63845/api/Functions/{0}", idFunction);
                var res = client.DownloadString(uri);
                var response = JsonConvert.DeserializeObject<Function>(res);

                return response;
            }
            catch (Exception)
            {
                return new List<Movie>();
                //throw;
            }
        }

        public object ExecuteBooking()
        {
            try
            {
                WebClient client = new WebClient();
                var uri = "http://localhost:63845/api/Bookings";
                var res = client.DownloadString(uri);
                var response = JsonConvert.DeserializeObject<List<Booking>>(res);

                return response;
            }
            catch (Exception)
            {
                return new List<Movie>();
                //throw;
            }
        }

        public void ExecuteSaveBooking(Booking booking)
        {
            try
            {
                WebClient client = new WebClient();
                var uri = string.Format("http://localhost:63845/api/Bookings");
                var json = JsonConvert.SerializeObject(booking);
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(uri, json);
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void ExecuteSaveSeatxFunction(SeatxFunction seatxFunction)
        {
            try
            {
                WebClient client = new WebClient();
                var uri = string.Format("http://localhost:63845/api/SeatxFunctions");
                var json = JsonConvert.SerializeObject(seatxFunction);
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(uri, json);
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}
