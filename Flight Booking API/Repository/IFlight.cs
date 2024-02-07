using flightapi.Models;

namespace flightapi.Repository
{
    public interface IFlight<KritikaFlight>
    {
        List<KritikaFlight> ShowAllFlights();
        void AddFlight (KritikaFlight kf);

        void UpdateFlight(int id,KritikaFlight kf);

        KritikaFlight GetFlight(int id);

        void DeleteFlight(int id);
    }
}