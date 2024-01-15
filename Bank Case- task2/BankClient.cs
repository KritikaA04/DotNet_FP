namespace assignment2
{
    class BankClient
    {
        
        public static void Main()
        {
            Console.Write("Available choice: ");
            Console.WriteLine("1. New Account");
            Console.WriteLine("2. Get Account Details");
            Console.WriteLine("3. Get All Accounts");
            Console.WriteLine("4. Deposit Amount");
            Console.WriteLine("5. Withdraw Amount");
            Console.WriteLine("6. Get Transaction details");
            Console.WriteLine("7. Exit");
            
            IBankRepo br= new BankRepo();

            bool exit= false;
            while(exit!=true)
            {
                Console.Write("Enter your choice: ");
                int choice=Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Account Number:");
                        int accno = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Customer Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Customer Address:");
                        string address = Console.ReadLine();

                        Console.WriteLine("Enter Initial current Balance:");
                        decimal balance = decimal.Parse(Console.ReadLine());

                        SBAccount newAccount = new SBAccount
                        {
                            AccountNumber = accno,
                            CustomerName = name,
                            CustomerAddress = address,
                            CurrentBalance = balance
                        };

                        br.NewAccount(newAccount);
                        Console.WriteLine("New Account created successfully.");

                        break;


                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Account Number:");
                            int acc = Convert.ToInt32(Console.ReadLine());

                            SBAccount account = br.GetAccountDetails(acc);
                            Console.WriteLine($"Account Details: {account.CustomerName}, {account.CustomerAddress}, Balance: {account.CurrentBalance}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                        
                    case 3:
                        List<SBAccount> temp= new List<SBAccount>();
                        temp = br.GetAllAccounts();
                        if(temp.Count==0)
                            Console.WriteLine("No records available!");
                        else
                        {
                            foreach(SBAccount sb in temp)
                            {
                                Console.WriteLine(sb.AccountNumber+" "+sb.CustomerName+" "+sb.CustomerAddress+" "+sb.CurrentBalance);
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Account Number:");
                        int dacc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount to be deposited:");
                        decimal damt = decimal.Parse(Console.ReadLine());
                        br.DepositAmount(dacc,damt);

                        break;

                    case 5:
                        Console.WriteLine("Enter Account Number:");
                        int wacc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount to be withdrawn:");
                        decimal wamt = decimal.Parse(Console.ReadLine());
                        br.WithdrawAmount(wacc,wamt);
                        break;

                    case 6:
                        List<SBTransaction> temp2= new List<SBTransaction>();
                        Console.WriteLine("Enter Account Number:");
                        int gtacc = Convert.ToInt32(Console.ReadLine());
                        temp2 = br.GetTransactions(gtacc);
                        if(temp2.Count==0)
                            Console.WriteLine("No records available!");
                        else
                        {
                            foreach(SBTransaction sb in temp2)
                            {
                                Console.WriteLine(sb.TransactionId+" "+sb.TransactionDate+" "+sb.AccountNumber+" "+sb.Amount+" "+sb.TransactionType);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }
    }
}