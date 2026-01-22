namespace ClassWork
{
    class Height
    {
        public int feet { get; set; }
        public double inches { get; set; }
        public Height()
        {
            feet = 5;
            inches = 5.0;
        }

        public Height(int ft, double inch)
        {
            feet = ft;
            inches = inch;
        }

        public Height(double inches)
        {
            if (inches >= 12)
            {
                feet += (int)(inches / 12);
                this.inches = inches % 12;
            }
        }
        public Height AddHeight(Height h)
        {
            int Totalfeet = this.feet + h.feet;
            double Totalinches = this.inches + h.inches;

            if (Totalinches >= 12)
            {
                Totalfeet += (int)(Totalinches / 12);
                Totalinches = Totalinches % 12;
            }
            return new Height(Totalfeet, Totalinches);
        }
        public override string ToString()
        {
            return $"Height: {feet} feet {inches} inches";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Height h1 = new Height(5, 6.5);
                Height h2 = new Height(5, 7.5);
                Height h3 = new Height(174);
                Console.WriteLine(h1);
                Console.WriteLine(h2);
                Console.WriteLine(h3);
                Console.WriteLine(h1.AddHeight(h2));
                Console.WriteLine(h3.AddHeight(h1));



            }

        }
    }
}