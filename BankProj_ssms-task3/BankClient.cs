using bankproj.Models;

namespace bankproj_ssms
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
        private static Ace52024Context db= new Ace52024Context();
        public static void Main()
        {
            Console.WriteLine("Available choice: ");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Get Account Details of an account");
            Console.WriteLine("3. Get All available Accounts");
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
                        KritikaSbaccount k = new KritikaSbaccount();
                        // Console.WriteLine("Enter Account Number:");
                        // k.AccountNumber=Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Customer Name:");
                        k.CustomerName= Console.ReadLine();

                        Console.WriteLine("Enter Customer Address:");
                        k.CustomerAddress= Console.ReadLine();

                        Console.WriteLine("Enter Initial current Balance:");
                        k.CurrentBalance= Decimal.Parse(Console.ReadLine());
                        try
                        {
                            br.NewAccount(k);
                            Console.WriteLine("New Account created successfully.");
                        }
                        catch(InvalidBalException x)
                        {
                            System.Console.WriteLine(x.Message);
                        }

                        break;


                    case 2:
                        // int acc;
                        Console.WriteLine("Enter Account Number:");
                        int acc=Convert.ToInt32(Console.ReadLine());
                        // int.TryParse(Console.ReadLine(),out acc);
                        try
                        {
                            KritikaSbaccount account = br.GetAccountDetails(acc);
                            if(account==null){
                                continue;
                            }
                            Console.WriteLine("Account No"+account.AccountNumber);
                            Console.WriteLine("Customer Name"+account.CustomerName);
                            Console.WriteLine("Customer Address"+account.CustomerAddress);
                            Console.WriteLine("Current Balance"+account.CurrentBalance);
                        }
                        catch (InvalidAccNoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                        
                    case 3:
                        // br.GetAllAccounts();
                        List<KritikaSbaccount> temp= new List<KritikaSbaccount>();
                        temp = br.GetAllAccounts();
                        if(temp.Count==0)
                        {
                            Console.WriteLine("No records available!");
                            continue;
                        }
                        else
                        {
                            foreach(var it in temp)
                            {
                                Console.WriteLine(it.AccountNumber+" "+it.CustomerName+" "+it.CustomerAddress+" "+it.CurrentBalance);
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
                        List<KritikaSbtransaction> temp2= new List<KritikaSbtransaction>();
                        Console.WriteLine("Enter Account Number:");
                        int gtacc = Convert.ToInt32(Console.ReadLine());
                        temp2=br.GetTransactions(gtacc);
                        // temp2 = br.GetTransactions(gtacc);
                        if(temp2.Count==0)
                        {
                            Console.WriteLine("No records available!");
                            continue;
                        }
                        else
                        {
                            foreach(var sb in temp2)
                            {
                                Console.WriteLine(sb.TransactionId+" "+sb.TransactionDate+" "+sb.AccountNumber+" "+sb.Amount+" "+sb.Transactiontype);
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
