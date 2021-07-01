namespace SharedTrip.ViewModels.Trips
{
    public class AllTripsViewModel
    {
        public string TripId { get; set; }
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public string DepartureTime { get; init; }
        public int Seats { get; init; }
    }
}
