namespace FleetManagement.Models
{
    public class GpsModel
    {
        public string TruckId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
