using System;
using System.Globalization;
using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Services.Contacts;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Controllers
{
    using static DataConstants;
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }
        [Authorize]
        public HttpResponse Add()
            => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddTripInputModel model)
        {
            var errors = this.validator.ValidateTrip(model);
            if (errors.Any())
            {
                return Error(errors);
            }
            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();
            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data.Trips
                .Select(x => new AllTripsViewModel()
                {
                    TripId = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Seats = x.Seats,
                    DepartureTime = x.DepartureTime.ToString(DateFormat),
                }).ToList();

            return View(trips);
        }


        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var validTrip = this.data.UserTrips
                .FirstOrDefault(x => x.TripId == tripId && x.UserId == this.User.Id);
            if (validTrip != null)
            {
                return Error($"You are already on this trip.");
            }
            var trip = this.data.Trips.Find(tripId);
            if (trip.Seats == 0)
            {
                return Error("Not enough free spaces on this trip.");
            }
            trip.Seats--;

            this.data.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                UserId = this.User.Id,
            });
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.data.Trips
                .Where(x => x.Id == tripId)
                .Select(x=> new DetailsTripViewModel()
                {
                    TripId = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    DepartureTime = x.DepartureTime.ToString("s"),
                }).FirstOrDefault();

            return View(trip);
        }
    }
}
