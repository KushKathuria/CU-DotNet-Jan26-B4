namespace FleetManagement.Services
{
    using Microsoft.Extensions.Hosting;

    public class GpsBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private static Random _rand = new Random();

        public static List<object> GpsDataStore = new List<object>();

        public GpsBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var gps = new
                {
                    TruckId = "TRK1",
                    Latitude = 30.7333 + (_rand.NextDouble() - 0.5) / 100,
                    Longitude = 76.7794 + (_rand.NextDouble() - 0.5) / 100,
                    Speed = _rand.Next(30, 90),
                    Timestamp = DateTime.UtcNow
                };

                GpsDataStore.Add(gps);

                Console.WriteLine($"GPS Updated: {gps.Latitude}, {gps.Longitude}");

                await Task.Delay(10000, stoppingToken); 
            }
        }
    }
}
