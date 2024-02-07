using flightapi.Models;
using flightapi.Repository;

namespace flightapi.Service
{
    public class FlightServ : IFlightServ<KritikaFlight>
    {
        private readonly IFlight<KritikaFlight> flightrepo;
        public FlightServ() {}

        public FlightServ(IFlight<KritikaFlight> _flightrepo)
        {
            flightrepo = _flightrepo;
        }
        public void AddFlight(KritikaFlight kf)
        {
            flightrepo.AddFlight(kf);
        }

        public void DeleteFlight(int id)
        {
            flightrepo.DeleteFlight(id);
        }

        public KritikaFlight GetFlight(int id)
        {
            return flightrepo.GetFlight(id);
        }

        public List<KritikaFlight> ShowAllFlights()
        {
            return flightrepo.ShowAllFlights();
        }

        public void UpdateFlight(int id, KritikaFlight kf)
        {
            flightrepo.UpdateFlight(id,kf);
        }
    }
}