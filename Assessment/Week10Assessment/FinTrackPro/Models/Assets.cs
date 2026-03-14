namespace FinTrackPro.Models
{
    public class Assets
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public string Type { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
