using Microsoft.EntityFrameworkCore;
using PHAdmin.API.DbContexts;
using PHAdmin.API.Entities;

namespace PHAdmin.API.Services
{
    public class PHAdminRepository : IPHAdminRepository
    {
        private readonly PHAdminContext _context;

        public PHAdminRepository(PHAdminContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Apartment?> GetApartmentAsync(int apartmentId)
        {
           return await _context.Apartments
                .Where (a => a.Id == apartmentId).FirstOrDefaultAsync();    
        }

        public async Task<IEnumerable<Apartment>> GetApartmentsAsync()
        {
            return await _context.Apartments.OrderBy(a => a.Id).ToListAsync();
        }
    }
}
