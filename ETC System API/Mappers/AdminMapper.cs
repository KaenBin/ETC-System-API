using ETC_System_API.DTOs.Admin;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class AdminMappers
    {
        public static AdminDto ToAdminDto(this Admin adminModel)
        {
            return new AdminDto
            {
                Id = adminModel.Id,
                FirstName = adminModel.FirstName,
                LastName = adminModel.LastName,
                ContactInfo = adminModel.ContactInfo
            };
        }

        public static Admin ToAdminFromCreateDto(this CreateAdminRequestDto adminDTO)
        {
            return new Admin
            {
                FirstName = adminDTO.FirstName,
                LastName = adminDTO.LastName,
                ContactInfo = adminDTO.ContactInfo
            };
        }
    }
}