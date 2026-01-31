using ClaSWork;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.Unicode;

namespace ClaSWork
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }

        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }
        public virtual decimal CalCulateFinalBill()
        {
            return BaseFee;
        }
    }
    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }
        public Inpatient(string Name, decimal BaseFee, int DaysStayed, decimal DailyRate) : base(Name, BaseFee)
        {
            this.DaysStayed = DaysStayed;
            this.DailyRate = DailyRate;
        }

        public override decimal CalCulateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }
    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        public Outpatient(string Name, decimal BaseFee, decimal procedureFee) : base(Name, BaseFee)
        {
            ProcedureFee = procedureFee;
        }
        public override decimal CalCulateFinalBill()
        {
            return ProcedureFee + BaseFee;
        }
    }

    class Emergencypatient : Patient
    {
        public int SeverityLevel { get; set; }
        public Emergencypatient(string Name, decimal BaseFee, int SeverityLevel) : base(Name, BaseFee)
        {
           this.SeverityLevel = SeverityLevel;
        }
        public override decimal CalCulateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }


    class HospitalBilling
    {
        List<Patient> list = new List<Patient>();
        public void AddPatient(Patient p)
        {
            list.Add(p);
        }

        public void GenerateDailyReport()
        {
            foreach (Patient p in list)
            {
                decimal bill = p.CalCulateFinalBill();
                Console.WriteLine($"Name: {p.Name}\n" +
                    $"Bill: {bill.ToString("C2")} ");
                Console.WriteLine("-----------------------------------");

            }

        }

        public decimal CalculateTotalRevenue()
        {
            decimal Total = 0;
            foreach (Patient p in list)
            {
                Total += p.CalCulateFinalBill();
            }
            return Total;
        }
        public int GetInpatientCount()
        {
            int count = 0;
            foreach (Patient p in list)
            {
                if (p is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            HospitalBilling billing = new HospitalBilling();

            billing.AddPatient(new Inpatient("Kush", 4500.354m, 3, 200m));
            billing.AddPatient(new Outpatient("A1", 756.55m, 150m));
            billing.AddPatient(new Emergencypatient("A2", 854.35m, 4));
            Console.OutputEncoding = Encoding.UTF8;

            billing.GenerateDailyReport();

            Console.WriteLine();

            Console.WriteLine($"Total Revenue: {billing.CalculateTotalRevenue():C2}");
            Console.WriteLine($"Inpatient Count: {billing.GetInpatientCount()}");
        }
    }
}