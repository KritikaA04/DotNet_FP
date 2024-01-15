namespace assignment2
{
    public interface IBankRepo
    {
        void NewAccount(SBAccount acc);

        List<SBAccount> GetAllAccounts();

        SBAccount GetAccountDetails(int accno);

        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        List<SBTransaction> GetTransactions(int accno);
    }
}