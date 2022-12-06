using PHAdmin.API.Entities;

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

        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<IEnumerable<Debt>> GetDebtsAsync();
    }
}
