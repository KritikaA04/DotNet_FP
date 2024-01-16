namespace banktask
{
    class InvalidAccNoException : ApplicationException
    {
        public InvalidAccNoException(string message):base(message){}
    }
    
    class InvalidBalException : ApplicationException
    {
        public InvalidBalException(string message):base(message){}
    }

    class DepositException : ApplicationException
    {
        public DepositException(string message):base(message){}
    }

    class WithdrawException : ApplicationException
    {
        public WithdrawException(string message):base(message){}
    }
    class BankClient
    {        
        public static void Main()
        {
            Console.WriteLine("Available choice: ");
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
                        int accno;
                        decimal balance;

                        Console.WriteLine("Enter Account Number:");
                        int.TryParse(Console.ReadLine(),out accno);

                        Console.WriteLine("Enter Customer Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Customer Address:");
                        string address = Console.ReadLine();

                        Console.WriteLine("Enter Initial current Balance:");
                        decimal.TryParse(Console.ReadLine(),out balance);
                        try
                        {
                            SBAccount newAcc = new SBAccount
                            {
                                AccountNumber = accno,
                                CustomerName = name,
                                CustomerAddress = address,
                                CurrentBalance = balance
                            };

                            br.NewAccount(newAcc);
                            Console.WriteLine("New Account created successfully.");
                        }
                        catch(Exception x)
                        {
                            switch (x)
                            {
                                case InvalidAccNoException:
                                    System.Console.WriteLine(x.Message);
                                    break;
                                case InvalidBalException:
                                    System.Console.WriteLine(x.Message);
                                    break;
                            }
                        }

                        break;


                    case 2:
                        int acc;
                        try
                        {
                            Console.WriteLine("Enter Account Number:");
                            int.TryParse(Console.ReadLine(),out acc);

                            SBAccount account = br.GetAccountDetails(acc);
                            Console.WriteLine($"Account Details: {account.CustomerName}, {account.CustomerAddress}, Balance: {account.CurrentBalance}");
                        }
                        catch (InvalidAccNoException ex)
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
                        decimal damt;
                        Console.WriteLine("Enter Account Number:");
                        int dacc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount to be deposited:");
                        decimal.TryParse(Console.ReadLine(),out damt);
                        try
                        {
                            br.DepositAmount(dacc,damt);
                        } 
                        catch(DepositException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        decimal wamt; 
                        Console.WriteLine("Enter Account Number:");
                        int wacc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount to be withdrawn:");
                        decimal.TryParse(Console.ReadLine(),out wamt);
                        try
                        {
                            br.WithdrawAmount(wacc,wamt);
                        }
                        catch(WithdrawException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
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


                    case 7:
                        exit=true;
                        Console.WriteLine("Program Exited!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }
    }
}
