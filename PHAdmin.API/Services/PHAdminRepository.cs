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
                .Where (e => e.Id == apartmentId).FirstOrDefaultAsync();    
        }

        public async Task<IEnumerable<Apartment>> GetApartmentsAsync()
        {
            return await _context.Apartments.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<ExpenseType>> GetExpenseTypesAsync()
        {
            return await _context.ExpenseTypes.OrderBy(e => e.Id).ToListAsync();
            
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            return await _context.Holidays.OrderBy(e => e.DateValue).ToListAsync();
        }

        public async Task<IEnumerable<PaymentType>> GetPaymentTypesAsync()
        {
            return await _context.PaymentTypes.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.Include(c => c.Users)
                .OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(e => e.Name).ToListAsync();
        }
    }
}
