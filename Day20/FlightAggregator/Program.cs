namespace FlightAggregator
{
    class FlightModel : IComparable<FlightModel>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(FlightModel other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"FlightNumber: {FlightNumber}  " +
                    $"Price: {Price}  " +
                    $"Duration: {Duration}  " +
                    $"DepartureTime: {DepartureTime}\n";
        }

    }
    class DurationSorter : IComparer<FlightModel>
    {
        public int Compare(FlightModel? x, FlightModel? y)
        {
            //if ((x == null) && (y == null)) return 0;
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Duration.CompareTo(y.Duration);
        }
    }
    class DepartureSorter : IComparer<FlightModel>
    {
        public int Compare(FlightModel? x, FlightModel? y)
        {
            //if ((x == null) && (y == null)) return 0;
            if (ReferenceEquals(x, y)) return 0;

            if (x == null) return -1;
            if (y == null) return 1;
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FlightModel> flights = new List<FlightModel>
        {
            new FlightModel
            {
                FlightNumber = "A1",
                Price = 500,
                Duration = new TimeSpan(2, 30, 0),
                DepartureTime = new DateTime()
            },
             null,

            new FlightModel
            {
                FlightNumber = "A2",
                Price = 4200,
                Duration = new TimeSpan(3, 10, 0),
                DepartureTime = new DateTime(2026, 1, 29, 6, 30, 0)
            },
            new FlightModel
            {
                FlightNumber = "A3",
                Price = 0,
                Duration = new TimeSpan(1, 50, 0),
                DepartureTime = new DateTime(2026, 1, 29, 8, 0, 0)
            }
        };
            //Console.WriteLine("default");
            //foreach (var flight in flights) {

            //    Console.WriteLine($"FlightNumber: {flight.FlightNumber}  " +
            //        $"Price: {flight.Price}  " +
            //        $"Duration: {flight.Duration}  " +
            //        $"DepartureTime: {flight.DepartureTime}");
            //}

            Console.WriteLine("Economy View");
            flights.Sort();
            foreach (var flight in flights)
            {
                if (flight == null)
                {
                    Console.WriteLine("Null Entry");
                    continue;
                }


                Console.WriteLine(flight);
            }

            Console.WriteLine("Buisness Runner View\n");
            flights.Sort(new DurationSorter());
            foreach (var flight in flights)
            {
                if (flight == null)
                {
                    Console.WriteLine("Null Entry");
                    continue;
                }
                Console.WriteLine(flight);

            }

            Console.WriteLine("Early Bird View");
            flights.Sort(new DepartureSorter());
            foreach (var flight in flights)
            {
                if (flight == null)
                {
                    Console.WriteLine("Null Entry");
                    continue;
                }

                Console.WriteLine(flight);

            }
        }
    }
}
