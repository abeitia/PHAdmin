using PHAdmin.API.Entities;

namespace PHAdmin.API.Services
{
    public interface IPHAdminRepository
    {
        Task<IEnumerable<Apartment>> GetApartmentsAsync();
        Task<Apartment?> GetApartmentAsync(int apartmentId);
    }
}
