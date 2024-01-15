namespace assignment2
{
    public class SBAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal CurrentBalance { get; set; }

        public SBAccount(){}

        public SBAccount(int acc, string cname, string caddress, decimal cbal)
        {
            AccountNumber = acc;
            CustomerName = cname;
            CustomerAddress = caddress;
            CurrentBalance = cbal;
        }
        
    }
}