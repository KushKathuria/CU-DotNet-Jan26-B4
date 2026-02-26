using System.Text;

namespace GymMemberShip
{
    internal class Program
    {
        public static double CalculateMembershipAmount(
    bool treadmill,
    bool weightLifting,
    bool zumba)
        {
            double total = 1000; 

            bool anyServiceSelected = false;

            if (treadmill)
            {
                total += 300;
                anyServiceSelected = true;
            }

            if (weightLifting)
            {
                total += 500;
                anyServiceSelected = true;
            }

            if (zumba)
            {
                total += 250;
                anyServiceSelected = true;
            }

            if (!anyServiceSelected)
            {
                total += 200;
            }

            total += total * 0.05;

            return total;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double amount = CalculateMembershipAmount(true, false, true);
            Console.WriteLine($"Total Monthly Amount: {amount:c2}");
        }
    }
}
