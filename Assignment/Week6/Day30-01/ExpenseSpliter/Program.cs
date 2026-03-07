
namespace ExpenseSpliter
{
    internal class Program
    {
        public static List<string> Splitter(Dictionary<string, double> dict)
        {
            List<string> result = new List<string>();

            Queue<KeyValuePair<string, double>> payer = new();
            Queue<KeyValuePair<string, double>> reciver = new();

            double totalSum = dict.Values.Sum();
            int persons = dict.Count;
            double share = totalSum / persons;

            foreach (var person in dict)
            {
                double diff = person.Value - share;

                if (diff > 0)
                    payer.Enqueue(new KeyValuePair<string, double>(person.Key, diff));
                else if (diff < 0)
                    reciver.Enqueue(new KeyValuePair<string, double>(person.Key, -diff));
            }

            while (payer.Count > 0 && reciver.Count > 0)
            {
                var cr = payer.Dequeue();
                var db = reciver.Dequeue();

                double amount = Math.Min(cr.Value, db.Value);

                result.Add($"{db.Key} gives {amount:F2} to {cr.Key}");

                if (cr.Value > amount)
                    payer.Enqueue(new KeyValuePair<string, double>(cr.Key, cr.Value - amount));

                if (db.Value > amount)
                    reciver.Enqueue(new KeyValuePair<string, double>(db.Key, db.Value - amount));
            }

            return result;
        }

        static void Main(string[] args)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>()
            {
                {"Person1", 900 },
                {"Person2", 700 },
                {"Person3", 2000 },
                {"Person4",1500 },
                {"Person5",3533 }
            };

            var settlements = Splitter(dict);

            foreach (var s in settlements)
                Console.WriteLine(s);
        }
    }
}
