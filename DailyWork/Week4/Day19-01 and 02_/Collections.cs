namespace ClaSWork
{
    abstract class Vechile
    {
        public String ModelName { get; set; }

        public Vechile(string modelName)
        {
            ModelName = modelName;
        }

        public abstract string Move();
        public virtual string GetFuelStatus()
        {
            return $"Fuel level is Stable";
        }
    }
    class ElectricCar : Vechile
    {
       public  ElectricCar(string ModelName) : base(ModelName) { }
        public override string Move()
        {
            return $"{ModelName} is Gliding Silently on battery Power ";
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} is at 80%";
        }

    }
    class HeavyTruck : Vechile
    {
       public  HeavyTruck(string Modelname) : base(Modelname) { }
        public override string Move()
        {
            return $"{ModelName} is hauling cargo with high-torque diesel power. ";
        }

    }
    class CargoPlane : Vechile
    {
        public CargoPlane(String ModelName) : base(ModelName) { }
        public override string Move()
        {
            return $"{ModelName}  is ascending to 30,000 feet. ";
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + $"checking jet fuel reserves..";
        }

    }
    internal class Collections
    {
        static void Main(string[] args)
        {
            Vechile[] v1 =
            {
                new ElectricCar("Tesla Model X"),
                new HeavyTruck("Volvo FH16"),
                new CargoPlane("Boeing 747")
            };

            foreach (Vechile vehicle in v1)
            {
                Console.WriteLine(vehicle.Move());
                Console.WriteLine(vehicle.GetFuelStatus());
                Console.WriteLine();
            }

        }
    }
}
