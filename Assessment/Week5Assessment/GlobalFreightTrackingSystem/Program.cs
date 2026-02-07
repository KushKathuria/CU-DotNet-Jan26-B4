namespace SwiftRouteLogistics
{
    public class RestrictedDestinationException : Exception
    {
        public string Location { get; }
        public RestrictedDestinationException(string location) : base($"Can't deliver to the Restriced Zone {location}")
        {
            Location = location;
        }
    }
    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException() : base($"Fragile Item Require Extra Precaution") { }
    }

    interface ILoggable
    {
        public void saveLog(string message);
    }
    class LogManager : ILoggable
    {
        string path = @"..\..\..\shipment_audit.log";
        public void saveLog(string message)
        {
            using StreamWriter sw = new StreamWriter(path, true);

            sw.WriteLine(message);
        }
    }
    public abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }
        public abstract void ProcessShipment();
    }

    class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight is Less than or equal to Zero");
            }
            if (IsFragile && !IsReinforced) throw new InsecurePackagingException();

            //Console.WriteLine($"ExpressShipment has Shipped product with ID: {TrackingId}");
        }
    }
    class HeavyFreight : Shipment
    {
        public bool IsHeavyPermit { get; set; }
        
        public override void ProcessShipment()
        {
            if (Weight <= 0) throw new ArgumentOutOfRangeException("Weight is Less than or equal to Zero");

            if (Weight > 1000 && !IsHeavyPermit) throw new Exception("The Heavy Weight parcel Requires HeavyPermit");
            if (IsFragile && !IsReinforced) throw new InsecurePackagingException();

            //Console.WriteLine($"HeavyFreight item is ready to ship");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            LogManager l = new LogManager();

            string[] RestrictedZones = { "North Pole", "Unkown Island" };
            List<Shipment> shipments = new List<Shipment>()
            {
                new ExpressShipment
                {
                    TrackingId="A1501",
                    Weight=865.47,
                    Destination="Sweden",
                    IsFragile=true,
                    IsReinforced=false
                },

                new HeavyFreight
                {
                    TrackingId="A1502",
                    Weight=1000,
                    Destination="North Pole",
                    IsHeavyPermit=false
                },
                new HeavyFreight
                {
                    TrackingId="A1503",
                    Weight=1043,
                    Destination="India",
                    IsHeavyPermit=true,
                    IsFragile=true,
                    IsReinforced=false

                },
                 new HeavyFreight
                {
                    TrackingId="A1504",
                    Weight=1020,
                    Destination="India",
                    IsHeavyPermit=true,
                    IsFragile=false,
                    IsReinforced=false

                },
                new HeavyFreight
                {
                    TrackingId="A1505",
                    Weight=875,
                    Destination="Sydney",
                    IsHeavyPermit=true,
                    IsReinforced=false,
                    IsFragile=false,
                },
                new ExpressShipment
                {
                    TrackingId="A1506",
                    Weight=0,
                    Destination="Unknon Island"
                }

            };

            foreach (var i in shipments)
            {
                try
                {
                    if (RestrictedZones.Contains(i.Destination))
                    {
                        throw new RestrictedDestinationException(i.Destination);
                    }
                    i.ProcessShipment();
                    l.saveLog($"Shipment processed Successfully");
                }
                catch (RestrictedDestinationException ex)
                {
                    l.saveLog($"Security Alert: {ex.Message}");

                }
                catch (ArgumentOutOfRangeException e)
                {
                    l.saveLog($"Data Entry Error: {e.Message}");
                }
                catch (Exception e)
                {
                    l.saveLog($"General Error: {e.Message}");
                }
                finally
                {
                    l.saveLog($"Shipment process finished for ID: {i.TrackingId}");
                }
            }
        }
    }
}
