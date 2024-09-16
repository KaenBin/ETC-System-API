using ETC_System_API.DTOs.Payment;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class PaymentMappers
    {
        public static PaymentDto ToPaymentDto(this Payment paymentModel)
        {
            return new PaymentDto
            {
                Id = paymentModel.Id,
                Amount = paymentModel.Amount,
                Method = paymentModel.Method,
                Status = paymentModel.Status,
                Date = paymentModel.Date,
                ReaderDevice = paymentModel.ReaderDevice.ToReaderDeviceDto(),
                TollTag = paymentModel.TollTag.ToTollTagDto()
            };
        }

        public static Payment ToPaymentFromCreateDto(this CreatePaymentRequestDto paymentDTO, ReaderDevice readerDevice, TollTag tollTag)
        {
            return new Payment
            {
                Amount = paymentDTO.Amount,
                Method = paymentDTO.Method,
                Status = "pending",
                Date = paymentDTO.Date,
                ReaderDeviceId = readerDevice.Id,
                ReaderDevice = readerDevice,
                TollTagId = tollTag.Id,
                TollTag = tollTag
            };
        }
    }
}