using Microsoft.EntityFrameworkCore;
using PHAdmin.API.DbContexts;
using PHAdmin.API.Entities;
using PHAdmin.API.Models;

namespace PHAdmin.API.Services
{
    public class PHAdminRepository : IPHAdminRepository
    {
        private readonly PHAdminContext _context;

        public PHAdminRepository(PHAdminContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddExpense(Expense expense)
        {
          //TODO: cambiar
            _context.Add(expense);
        }

        public void AddExpenseWithDocument(Expense expense)
        { _context.Add(expense);
            _context.Expenses.Add(expense);
        }

        public void DeleteExpense(Expense expense)
        {
            //TODO: cambiar
            _context.Remove(expense);
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

        public async Task<IEnumerable<Debt>> GetDebtsAsync()
        {
            return await _context.Debts.OrderBy(e => e.Id).ToListAsync();
        }

        public async Task<Expense?> GetExpense2Async(int expenseId)
        {
            return await _context.Expenses
                .Where(e => e.Id == expenseId).FirstOrDefaultAsync();
        }

        public async Task<ExpenseDto?> GetExpenseAsync(int expenseId)
        {
            return await _context.Expenses.Join(_context.ExpenseTypes,
                e => e.ExpenseTypeId,
                et => et.Id,
                (e, et) => new ExpenseDto
                {
                    Id = e.Id,
                    ExpenseDate = e.ExpenseDate,
                    ExpenseTypeName = et.ExpenseName,
                    ExpenseTypeId = e.ExpenseTypeId,
                    Amount = e.Amount,
                    Comments = e.Comments,
                    CreationDate = e.CreationDate,
                    Status = e.Status
                })
                .Where(e => e.Id == expenseId).FirstOrDefaultAsync();
        }

       

        public async Task<IEnumerable<ExpenseDto>> GetExpensesAsync()
        {
            //return await _context.Expenses.OrderBy(e => e.Id).ToListAsync();
            return await _context.Expenses.Join(_context.ExpenseTypes,
                e => e.ExpenseTypeId,
                et => et.Id,
                (e, et) => new ExpenseDto
                {
                    Id = e.Id,
                    ExpenseDate = e.ExpenseDate,
                    ExpenseTypeName = et.ExpenseName,
                    ExpenseTypeId = e.ExpenseTypeId,
                    Amount = e.Amount,
                    Comments = e.Comments,
                    CreationDate  = e.CreationDate,
                    Status = e.Status
                }).Where(e => e.Status == "A").ToListAsync();

        }

        public async Task<IEnumerable<ExpenseType>> GetExpenseTypesAsync()
        {
            return await _context.ExpenseTypes.OrderBy(e => e.Id).ToListAsync();
            
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            return await _context.Holidays.OrderBy(e => e.DateValue).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _context.Payments.OrderBy(e => e.Id).ToListAsync();
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
