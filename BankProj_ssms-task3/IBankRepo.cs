using bankproj.Models;

namespace bankproj_ssms
{
    public interface IBankRepo
    {
        void NewAccount(KritikaSbaccount acc);

        List<KritikaSbaccount> GetAllAccounts();

        KritikaSbaccount GetAccountDetails(int accno);

        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        List<KritikaSbtransaction> GetTransactions(int accno);
    }
}