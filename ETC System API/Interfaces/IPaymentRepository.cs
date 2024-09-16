using ETC_System_API.Models;
using ETC_System_API.DTOs.Payment;

namespace ETC_System_API.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task<Payment> CreateAsync(Payment paymentModel);
        Task<Payment?> UpdateAsync(int id, UpdatePaymentRequestDto paymentDto);
        Task<Payment?> DeleteAsync(int id);
    }
}