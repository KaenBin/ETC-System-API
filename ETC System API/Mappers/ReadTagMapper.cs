using ETC_System_API.DTOs.ReadTag;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class ReadTagMappers
    {
        public static ReadTagDto ToReadTagDto(this ReadTag readTagModel)
        {
            return new ReadTagDto
            {
                ReadTime = readTagModel.ReadTime,
                Status = readTagModel.Status,
                TollTag = readTagModel.TollTag.ToTollTagDto()
            };
        }
        // public static readTag ToreadTagFromCreateDto(this readTagDto readTagDto)
        // {
        //     return new readTag
        //     {
        //         Id = readTagDto.Id,
        //         Name = readTagDto.Name
        //     };
        // }
    }
}