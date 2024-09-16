using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.Interfaces;
using ETC_System_API.DTOs.Payment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IAdminRepository _adminRepo;
        public readonly IReaderDeviceRepository _readerDeviceRepo;
        public readonly ITollTagRepository _tollTagRepo;
        public PaymentController(IPaymentRepository paymentRepo, IAdminRepository adminRepo, IReaderDeviceRepository readerDeviceRepo, ITollTagRepository tollTagRepo)
        {
            _paymentRepo = paymentRepo;
            _adminRepo = adminRepo;
            _readerDeviceRepo = readerDeviceRepo;
            _tollTagRepo = tollTagRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentRepo.GetAllAsync();

            return Ok(payments.Select(s => s.ToPaymentDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var payment = await _paymentRepo.GetByIdAsync(id);

            if (payment == null)
                return NotFound();

            return Ok(payment.ToPaymentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentRequestDto paymentDto, [FromQuery] int readerDeviceId = -1, [FromQuery] int tollTagId = -1)
        {
            if (readerDeviceId == -1 || tollTagId == -1)
                return BadRequest("Reader device and toll tag required to create payment.");
            var readerDevice = await _readerDeviceRepo.GetByIdAsync(readerDeviceId);
            if (readerDevice == null)
                return NotFound("Reader device not found!");
            var tollTag = await _tollTagRepo.GetByIdAsync(tollTagId);
            if (tollTag == null)
                return NotFound("Toll tag not found!");
            var paymentModel = paymentDto.ToPaymentFromCreateDto(readerDevice, tollTag);
            await _paymentRepo.CreateAsync(paymentModel);
            return CreatedAtAction(nameof(GetById), new { id = paymentModel.Id }, paymentModel.ToPaymentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdatePaymentRequestDto paymentDto)
        {
            var paymentModel = await _paymentRepo.UpdateAsync(id, paymentDto);

            if (paymentModel == null)
                return NotFound();

            return Ok(paymentModel.ToPaymentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var paymentModel = await _paymentRepo.DeleteAsync(id);

            if (paymentModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
