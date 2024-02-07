using flightapi.Models;

namespace flightapi.Repository
{
    public class FlightRepo : IFlight<KritikaFlight>
    {
        private readonly Ace52024Context db;
        public FlightRepo(){}

        public FlightRepo(Ace52024Context _db)
        {
            db=_db;
        }
        public void AddFlight(KritikaFlight kf)
        {
            db.KritikaFlights.Add(kf);
            db.SaveChanges();
        }

        public void DeleteFlight(int id)
        {
            KritikaFlight kx=db.KritikaFlights.Find(id);
            db.KritikaFlights.Remove(kx);
            db.SaveChanges();
        }

        public void UpdateFlight(int id, KritikaFlight kf)
        {
            KritikaFlight kx=db.KritikaFlights.Find(id);
            db.KritikaFlights.Update(kx);
            db.SaveChanges();
        }

        public KritikaFlight GetFlight(int id)
        {
            return db.KritikaFlights.Find(id);
        }

        public List<KritikaFlight> ShowAllFlights()
        {
            return db.KritikaFlights.ToList();
        }
    }
}