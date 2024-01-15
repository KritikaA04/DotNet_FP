using bankproj.Models;

namespace bankproj_ssms
{
    public class BankRepo : IBankRepo
    {
        private static Ace52024Context db= new Ace52024Context();
        // KritikaSbaccount ksba = new KritikaSbaccount();
        // KritikaSbtransaction ksbt = new KritikaSbtransaction();

        public KritikaSbaccount GetAccountDetails(int accno)
        {
            KritikaSbaccount ksba = db.KritikaSbaccounts.Find(accno);
            db.SaveChanges();
            if(ksba== null)
                throw new InvalidAccNoException("Account Not Found!");
            return ksba;
            
        }

        public void NewAccount(KritikaSbaccount acc)
        {
            if(acc.AccountNumber <0)
            {
                throw new InvalidAccNoException("Please enter a valid account number!");
            }
            if(acc.CurrentBalance < 0)
            {
                throw new InvalidBalException("The balance amount entered doesn't seem to be valid! Please try again");
            }
            else
            {
                System.Console.WriteLine("Adding SBAccount details");
                db.KritikaSbaccounts.Add(acc);
                db.SaveChanges();
                System.Console.WriteLine("Changes Saved, account is successfully added!");
            }

        }

        public List<KritikaSbaccount> GetAllAccounts()
        {
            // KritikaSbaccount ksba = new KritikaSbaccount();
            List<KritikaSbaccount> res= (from i in db.KritikaSbaccounts
                                        select i).ToList();
            // foreach(var it in db.KritikaSbaccounts)
            // {
            //     System.Console.WriteLine(it.AccountNumber);
            // }
            return res;
        }

        public void DepositAmount(int accno, decimal amt)
        {
            // var findacc = ListAcc.Find(x => x.AccountNumber == accno);

            KritikaSbaccount ksba  = db.KritikaSbaccounts.Find(accno);
            if(ksba == null)
                throw new InvalidAccNoException("Account Not Found!");
            if(amt < 0)
                throw new DepositException("Please enter a valid amount to be deposited!");
            else
            {
                ksba.CurrentBalance += amt;
                // transID++;
                db.KritikaSbaccounts.Update(ksba);
                KritikaSbtransaction ksbt = new KritikaSbtransaction();
                ksbt.TransactionDate= DateTime.Now;
                ksbt.AccountNumber=accno;
                ksbt.Amount=amt;
                ksbt.Transactiontype="Deposit";
                db.KritikaSbtransactions.Add(ksbt);
                db.SaveChanges();
                Console.WriteLine("Amount has been Deposited!");
            }
        
            return;

        }

        public void WithdrawAmount(int accno, decimal amt)
        {
            // var findacc = ListAcc.Find(x => x.AccountNumber == accno);
            KritikaSbaccount ksba = new KritikaSbaccount();
            ksba = db.KritikaSbaccounts.Find(accno);
            if(ksba!= null)
            {
                if(ksba.CurrentBalance < amt)
                {
                    throw new WithdrawException("No sufficient Balance!");
                }
                else
                {
                    ksba.CurrentBalance -= amt;
                    // transID++;
                    db.KritikaSbaccounts.Update(ksba);
                    KritikaSbtransaction ksbt = new KritikaSbtransaction();
                    ksbt.TransactionDate= DateTime.Now;
                    ksbt.AccountNumber= accno;
                    ksbt.Amount = amt;
                    ksbt.Transactiontype= "Withdraw";
                    db.KritikaSbtransactions.Add(ksbt);
                    db.SaveChanges();
                    Console.WriteLine("Amount has been Withdrawn!");

                    return;
                }
            }    
            else
            {
                throw new InvalidAccNoException("Account Not Found!");
            }
        }

        List<KritikaSbtransaction> IBankRepo.GetTransactions(int accno)
        {
            
            // KritikaSbtransaction ksbt = new KritikaSbtransaction();
            List<KritikaSbtransaction> res = (from i in db.KritikaSbtransactions
                                        where i.AccountNumber==accno 
                                        select i).ToList();
            // ksbt = db.KritikaSbtransactions.Find(accno);

            // foreach(var it in db.KritikaSbtransactions)
            // {
            //     System.Console.WriteLine(it.TransactionId+" "+it.TransactionDate+" "+it.AccountNumber+" "+it.Amount+" "+it.Transactiontype);
            // }
            return res;
        }
    }
    
}
