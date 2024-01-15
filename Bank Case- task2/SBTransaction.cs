namespace assignment2
{
    public class SBTransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }

        
        public SBTransaction(){}

        public SBTransaction(int tid, DateTime tdate, int acc, decimal amt, string ttype)
        {
            TransactionId= tid;
            TransactionDate= tdate;
            AccountNumber = acc;
            Amount = amt;
            TransactionType = ttype;
        }

    }
}