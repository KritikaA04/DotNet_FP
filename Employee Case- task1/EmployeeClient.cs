namespace assignment1
{
    class EmployeeClient
    {
        public static void Main()
        {
            Permanent pe = new Permanent();
            pe.AcceptDetails();
            pe.DisplayDetails();
            // pe.GetDetails();
            // pe.ShowDetails();
            pe.CalculateSalary();
            
            Trainee te = new Trainee();
            te.AcceptDetails();
            te.DisplayDetails();
            // te.GetTraineeDetails();
            // te.ShowTraineeDetails();
            te.CalculateSalary();
            
        }
    }
}