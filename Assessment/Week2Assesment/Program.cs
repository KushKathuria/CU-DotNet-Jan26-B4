namespace Week2Assesment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums= new decimal[5];
            for (int i = 0; i < 5; i++)
            {
                string name;
                decimal premium;
                do
                {
                    Console.WriteLine($"Enter Holder Name{i+1} :");
                    name = Console.ReadLine();
                    policyHolderNames[i] = name;
                }
                while (string.IsNullOrWhiteSpace(name) );

                do
                {
                    Console.WriteLine($"Enter Premium Details :");
                   premium=decimal.Parse(Console.ReadLine());
                    annualPremiums[i] = premium;    
                }
                while( premium < 0);
            }
            decimal premiumSum= 0m;
            decimal AveragePremium=0m;
            decimal highestPremium= decimal.MinValue;
            decimal lowestPremium= decimal.MaxValue;
            foreach (var premium in annualPremiums)
            {
                premiumSum+=premium;
                if (premium > highestPremium)
                {
                    highestPremium = premium;
                }
                if (premium < lowestPremium)
                {
                    lowestPremium = premium;
                }
            }

            AveragePremium=premiumSum/annualPremiums.Length;
           

            Console.WriteLine();
            Console.WriteLine("INSURANCE PREMIUM SUMMARY");
            Console.WriteLine("-------------------------");
            Console.WriteLine("{0,-20} {1,15} {2,10}", "POLICY HOLDER", "PREMIUM", "CATEGORY");

            for (int i=0;i<5;i++)
            {
                string category;

                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";

                Console.WriteLine(
                    "{0,-20} {1,15:F2} {2,10}",
                    policyHolderNames[i].ToUpper(),
                    annualPremiums[i],
                    category
                );
            }


            Console.WriteLine($"premiumSum: {premiumSum:f2}");
            Console.WriteLine($"AveragePremium: {AveragePremium:f2}");
            Console.WriteLine($"highestPremium: {highestPremium:f2}");
            Console.WriteLine($"lowestPremium: {lowestPremium:f2}");













        }
    }
}
