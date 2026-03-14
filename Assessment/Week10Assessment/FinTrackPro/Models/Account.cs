namespace FinTrackPro.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public double Balance { get; set; }
      public  List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

}
