
namespace flightapi.Service
{
    // service layer has business logic
    public interface IFlightServ<KritikaFlight>
    {
        List<KritikaFlight> ShowAllFlights();
        void AddFlight (KritikaFlight kf);

        void UpdateFlight(int id,KritikaFlight kf);

        KritikaFlight GetFlight(int id);

        void DeleteFlight(int id);

        // these are necessary plus it can return other things as well
        string Message(string name)
        {
            return "Hello" +name;
        }
    }
}