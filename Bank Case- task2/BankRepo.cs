namespace banktask
{
    public class BankRepo : IBankRepo
    {
        List<SBAccount> ListAcc = new List<SBAccount>();
        List<SBTransaction> ListTrans = new List<SBTransaction>();
        int transID = 1;
        public SBAccount GetAccountDetails(int accno)
        {
            var findacc = ListAcc.Find(x => x.AccountNumber == accno);
            if(findacc== null)
                throw new InvalidAccNoException("Account Not Found!");
            return findacc;
            
        }

        public void NewAccount(SBAccount acc)
        {
            if(acc.AccountNumber <0)
            {
                throw new InvalidAccNoException("Please enter a valid account number!");
            }
            if(acc.CurrentBalance < 0)
            {
                throw new InvalidBalException("The baance amount entered doesn't seem to be valid! Please try again");
            }
            else
            {
                System.Console.WriteLine("Add SBAccount details: ");
                ListAcc.Add(acc);
            }

        }

        public List<SBAccount> GetAllAccounts()
        {
            return ListAcc;
        }

        public void DepositAmount(int accno, decimal amt)
        {
            var findacc = ListAcc.Find(x => x.AccountNumber == accno);
            if(findacc == null)
                throw new InvalidAccNoException("Account Not Found!");
            if(amt < 0)
                throw new DepositException("Please enter a valid amount to be deposited!");
            else
            {
                findacc.CurrentBalance += amt;
                transID++;
                DateTime now= DateTime.Now;
                ListTrans.Add(new SBTransaction(transID,now,accno,findacc.CurrentBalance,"Deposit"));
                Console.WriteLine("Amount has been Deposited!");
            }
        
            return;

        }

        public void WithdrawAmount(int accno, decimal amt)
        {
            var findacc = ListAcc.Find(x => x.AccountNumber == accno);
            if(findacc == null)
                throw new InvalidAccNoException("Account Not Found!");
            if(findacc.CurrentBalance >= amt)
            {
                findacc.CurrentBalance -= amt;
                transID++;
                DateTime now= DateTime.Now;
                ListTrans.Add(new SBTransaction(transID,now,accno,findacc.CurrentBalance,"Withdraw"));
                Console.WriteLine("Amount has been Withdrawn!");

                return;
            }    
            else
            {
                throw new WithdrawException("No sufficient Balance!");
                return;
            }
        }

        List<SBTransaction> IBankRepo.GetTransactions(int accno)
        {
            List<SBTransaction> res = new List<SBTransaction>();
            var findacc = ListTrans.Find(x => x.AccountNumber == accno);
            if(findacc != null)
            {
                res.Add(findacc);
                // res.Add(findacc);
            }
            return res;
        }
    }
    
}
