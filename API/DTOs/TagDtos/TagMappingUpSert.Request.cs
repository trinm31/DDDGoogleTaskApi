using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Conventions;

namespace API.DTOs.TagDtos
{
    public class TagMappingUpSertRequest
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int TaskId { get; set; }
    }
}
