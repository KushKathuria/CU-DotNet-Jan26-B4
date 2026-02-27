using System;
using System.Collections.Generic;

namespace KitchenAppliances
{
    public abstract class Appliance
    {
        public string ModelName { get; set; }
        public int PowerConsumption { get; set; }

        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine("No preheating required.");
        }
    }

    public interface ITimer
    {
        void SetTimer(int minutes);
    }

    public interface IWiFi
    {
        void ConnectWiFi();
    }

    public class Microwave : Appliance, ITimer
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Microwave timer set for {minutes} minutes");
        }

        public override void Cook()
        {
            Console.WriteLine("Microwave cooking food...");
        }
    }

    public class ElectricOven : Appliance, ITimer, IWiFi
    {
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Oven timer set for {minutes} minutes");
        }

        public void ConnectWiFi()
        {
            Console.WriteLine("Oven connected to WiFi");
        }

        public override void Preheat()
        {
            Console.WriteLine("Oven preheating...");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine("Oven cooking food...");
        }
    }

    public class AirFryer : Appliance
    {
        public override void Cook()
        {
            Console.WriteLine("Air Fryer cooking quickly...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> appliances = new List<Appliance>()
            {
                new Microwave
                {
                    ModelName="MW-101",
                    PowerConsumption=1200
                },

                new ElectricOven
                {
                    ModelName="OV-900",
                    PowerConsumption=2000
                },

                new AirFryer
                {
                    ModelName="AF-500",
                    PowerConsumption=1500
                }
            };

            foreach (var device in appliances)
            {
                Console.WriteLine($"\nDevice: {device.ModelName}");
                device.Cook();

                if (device is IWiFi wifi)
                {
                    wifi.ConnectWiFi();
                }
            }
        }
    }
}