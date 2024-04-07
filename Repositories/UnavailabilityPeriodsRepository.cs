using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Repositories
{
    public class UnavailabilityPeriodsRepository
    {
        private readonly ConferenceRoomBookingDbContext _context;
        public UnavailabilityPeriodsRepository(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }
        private List<UnavailabilityPeriods> unavailabilityPeriods = new List<UnavailabilityPeriods>();
        private int nextId = 1;

        public void Create(UnavailabilityPeriods period)
        {
            period.Id = nextId++;
            unavailabilityPeriods.Add(period);
        }

        public IEnumerable<UnavailabilityPeriods> ListByMonth(int year, int month)
        {
            return unavailabilityPeriods
                .Where(p => p.StartDate.Year == year && p.StartDate.Month == month && !p.IsDeleted)
                .OrderBy(p => p.StartDate);
        }

        public void Update(UnavailabilityPeriods updatedPeriod)
        {
            var existingPeriod = unavailabilityPeriods.FirstOrDefault(p => p.Id == updatedPeriod.Id && !p.IsDeleted);
            if (existingPeriod != null)
            {
                existingPeriod.StartDate = updatedPeriod.StartDate;
                existingPeriod.EndDate = updatedPeriod.EndDate;
            }
        }

        public void DeleteSoft(int id)
        {
            var periodToDelete = unavailabilityPeriods.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
            if (periodToDelete != null)
            {
                periodToDelete.IsDeleted = true;
            }
        }

        public bool IsDateUnavailable(DateTime date)
        {
            return unavailabilityPeriods.Any(p => !p.IsDeleted && date >= p.StartDate && date <= p.EndDate);
        }
    }
}
