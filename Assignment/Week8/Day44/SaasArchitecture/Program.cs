using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SaasArchitecture
{


    abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            if (obj is Subscriber s)
                return ID.Equals(s.ID);
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            int result = JoinDate.CompareTo(other.JoinDate);
            if (result == 0)
                result = Name.CompareTo(other.Name);
            return result;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===== REVENUE REPORT =====");
            sb.AppendLine("Name\tType\tJoinDate\tMonthlyBill");

            foreach (var s in subscribers)
            {
                string type = s.GetType().Name.Replace("Subscriber", "");
                sb.AppendLine($"{s.Name}\t{type}\t{s.JoinDate.ToShortDateString()}\t{s.CalculateMonthlyBill():C}");
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();
            Console.OutputEncoding = Encoding.UTF8;
            subscribers.Add("a@saas.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Alpha Corp",
                JoinDate = new DateTime(2023, 2, 1),
                FixedRate = 500,
                TaxRate = 0.18m
            });

            subscribers.Add("b@saas.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Ravi",
                JoinDate = new DateTime(2024, 1, 10),
                DataUsageGB = 120,
                PricePerGB = 2
            });

            subscribers.Add("c@saas.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Beta Ltd",
                JoinDate = new DateTime(2022, 5, 5),
                FixedRate = 800,
                TaxRate = 0.20m
            });

            subscribers.Add("d@saas.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Anita",
                JoinDate = new DateTime(2023, 11, 20),
                DataUsageGB = 60,
                PricePerGB = 3
            });

            subscribers.Add("e@saas.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Karan",
                JoinDate = new DateTime(2022, 9, 15),
                DataUsageGB = 200,
                PricePerGB = 1.5m
            });

            var sorted = subscribers
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();

            ReportGenerator.PrintRevenueReport(sorted);
        }
    }
}

