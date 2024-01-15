namespace assignment1
{
    interface IEmployee
    {
        void AcceptDetails();
        void CalculateSalary();
        void DisplayDetails();
    }
    abstract class Employee : IEmployee
    {
        public int Eid{get;set;}
        public string Ename{get;set;}
        public float Esalary{get;set;}
        public DateTime Edoj{get;set;}

        public virtual void AcceptDetails()
        {
            System.Console.WriteLine("Enter Employee ID:");
            Eid= Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter Name:");
            Ename = Console.ReadLine();
            System.Console.WriteLine("Enter Salary:");
            Esalary = float.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter date of joining:");
            Edoj = Convert.ToDateTime(Console.ReadLine());
        }

        public virtual void DisplayDetails()
        {
            System.Console.WriteLine("Employee ID:"+Eid);
            System.Console.WriteLine("Employee Name:"+Ename);
            System.Console.WriteLine("Employee DOJ:"+Edoj);
        }

        public abstract void CalculateSalary();
       
    }

    class Permanent : Employee
    {
        
        public int Basicpay{get;set;}
        public int HRA{get;set;}
        public int DA{get;set;}
        public int PF{get;set;}

        public override void AcceptDetails()
        {
            base.AcceptDetails();
            System.Console.WriteLine("Enter basicpay:");
            Basicpay= Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter HRA:");
            HRA= Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter DA:");
            DA= Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter PF:");
            PF= Convert.ToInt32(Console.ReadLine());
        }

         public override void DisplayDetails()
        {
            base.DisplayDetails();
            System.Console.WriteLine("Employee basicpay:"+Basicpay);
            System.Console.WriteLine("Employee HRA:"+HRA);
            System.Console.WriteLine("Employee DA:"+DA);
            System.Console.WriteLine("Employee PF:"+PF);
        }

        public override void CalculateSalary()
        {
            Esalary= +Basicpay + HRA + DA - PF;
            System.Console.WriteLine("Salary of permanent employee:"+Esalary);
        }
    }

    class Trainee : Employee
    {
        public int Bonus{get;set;}
        public string Projectname{get;set;}

        public override void AcceptDetails()
        {
            base.AcceptDetails();
            System.Console.WriteLine("Enter projectname:");
            Projectname= Console.ReadLine();
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            System.Console.WriteLine("projectname:"+Projectname);
        }
        public override void CalculateSalary()
        {
            if(Projectname.ToLower().Equals("Banking"))
            {
                Esalary= float.Parse(((0.05 * Esalary) + Esalary).ToString());
                System.Console.WriteLine("Employee salary of banking trainee:"+Esalary);
            }
            if(Projectname.ToLower().Equals("Insurance"))
            {
                Esalary= float.Parse(((0.1 * Esalary) + Esalary).ToString());
                System.Console.WriteLine("Employee salary of insurance trainee:"+Esalary);
            }
        }
    }
}