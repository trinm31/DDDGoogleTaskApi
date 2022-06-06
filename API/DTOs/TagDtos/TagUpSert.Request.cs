using System.ComponentModel.DataAnnotations;

namespace API.DTOs.TagDtos
{
    public class TagUpSertRequest
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
