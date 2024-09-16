using ETC_System_API.Data;
using ETC_System_API.DTOs.Payment;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{

    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDBContext _context;
        public PaymentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreateAsync(Payment paymentModel)
        {
            await _context.Payment.AddAsync(paymentModel);
            await _context.SaveChangesAsync();
            return paymentModel;
        }

        public async Task<Payment?> DeleteAsync(int id)
        {
            var paymentModel = await _context.Payment.FirstOrDefaultAsync(x => x.Id == id);
            if (paymentModel == null)
                return null;
            _context.Remove(paymentModel);
            await _context.SaveChangesAsync();
            return paymentModel;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payment.Include(x => x.ReaderDevice).Include(x => x.TollTag).ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payment
                .Include(x => x.ReaderDevice).ThenInclude(x => x.TollStation)
                .Include(x => x.TollTag)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payment?> UpdateAsync(int id, UpdatePaymentRequestDto paymentDto)
        {
            var existingPayment = await _context.Payment
                .Include(x => x.ReaderDevice).ThenInclude(x => x.TollStation)
                .Include(x => x.TollTag)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingPayment == null)
                return null;

            existingPayment.Amount = paymentDto.Amount;
            existingPayment.Method = paymentDto.Method;
            existingPayment.Status = paymentDto.Status;
            existingPayment.Date = paymentDto.Date;

            await _context.SaveChangesAsync();

            return existingPayment;
        }
    }
}