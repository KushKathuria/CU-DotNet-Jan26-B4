using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasworkk
{
    internal class newClassWork
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach (KeyValuePair<double, string> i in leaderboard)
            {
                Console.WriteLine($"LapTime :{i.Key:f2}  Name: {i.Value}");
            }
            double winner = leaderboard.Keys.First();
            Console.WriteLine($"Winner: {winner}\n" +
                $"Name: {leaderboard[winner]}");
            bool id = leaderboard.ContainsValue("SteadyEddie");
            var sa = leaderboard.FirstOrDefault(x => x.Value.Equals("SteadyEdd")).Key;

            Console.WriteLine(sa);
            leaderboard.Remove(sa);
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Updated Record");
            foreach (KeyValuePair<double, string> i in leaderboard)
            {
                Console.WriteLine($"LapTime :{i.Key:f2}  Name: {i.Value}");
            }

        }
    }
}
