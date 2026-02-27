namespace OlaDriver
{
    public class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }
    }
    public class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }

        public List<Ride> Rides { get; set; } = new List<Ride>();

        public decimal GetTotalFare()
        {
            decimal total = 0;

            foreach (var ride in Rides)
            {
                total += ride.Fare;
            }

            return total;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();

            OLADriver d1 = new OLADriver
            {
                Id = 1,
                Name = "Rahul",
                VehicleNo = "PB10AA1234"
            };

            d1.Rides.Add(new Ride { RideID = 101, From = "Chandigarh", To = "Mohali", Fare = 250 });
            d1.Rides.Add(new Ride { RideID = 102, From = "Mohali", To = "Kharar", Fare = 150 });

            drivers.Add(d1);

            OLADriver d2 = new OLADriver
            {
                Id = 2,
                Name = "Amit",
                VehicleNo = "PB65BB5678"
            };

            d2.Rides.Add(new Ride { RideID = 201, From = "Kharar", To = "Chandigarh", Fare = 300 });
            d2.Rides.Add(new Ride { RideID = 202, From = "Zirakpur", To = "Airport", Fare = 400 });

            drivers.Add(d2);

            foreach (var driver in drivers)
            {
                Console.WriteLine($"Driver: {driver.Name}");
                Console.WriteLine($"Vehicle: {driver.VehicleNo}");

                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine(
                        $"RideID: {ride.RideID} | {ride.From} -> {ride.To} | Fare: {ride.Fare}");
                }

                Console.WriteLine($"Total Fare: {driver.GetTotalFare()}");
                Console.WriteLine("--------------------------------");

            }
        }
    }
}
