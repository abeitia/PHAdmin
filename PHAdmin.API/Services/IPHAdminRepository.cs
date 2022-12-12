using PHAdmin.API.Entities;
using PHAdmin.API.Models;

namespace PHAdmin.API.Services
{
    public interface IPHAdminRepository
    {
        Task<IEnumerable<Apartment>> GetApartmentsAsync();
        Task<Apartment?> GetApartmentAsync(int apartmentId);

        Task<IEnumerable<Role>> GetRolesAsync();

        Task<IEnumerable<ExpenseType>> GetExpenseTypesAsync();

        Task<IEnumerable<PaymentType>> GetPaymentTypesAsync();

        Task<IEnumerable<Holiday>> GetHolidaysAsync();

        Task<IEnumerable<User>> GetUsersAsync();

        Task<IEnumerable<Payment>> GetPaymentsAsync();

        Task<IEnumerable<ExpenseDto>> GetExpensesAsync();
       
        Task<ExpenseDto?> GetExpenseAsync(int expenseId);
        Task<Expense?> GetExpense2Async(int expenseId);

        Task<IEnumerable<Debt>> GetDebtsAsync();

        void AddExpense(Expense expense);
        void AddExpenseWithDocument(Expense expense);

        Task<bool> SaveChangesAsync();

        void DeleteExpense(Expense expense);
    }
}
