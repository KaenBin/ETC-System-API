using ETC_System_API.DTOs.ManageTag;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class ManageTagMappers
    {
        public static ManageTagDto ToManageTagDto(this ManageTag manageTagModel)
        {
            return new ManageTagDto
            {
                TollTagId = manageTagModel.TollTagId,
                AdminId = manageTagModel.AdminId,
                AccessLevel = manageTagModel.AccessLevel
            };
        }
        // public static ManageTag ToManageTagFromCreateDto(this ManageTagDto manageTagDto)
        // {
        //     return new ManageTag
        //     {
        //         Id = manageTagDto.Id,
        //         Name = manageTagDto.Name
        //     };
        // }
    }
}