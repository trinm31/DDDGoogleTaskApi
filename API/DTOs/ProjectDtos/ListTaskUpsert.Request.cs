namespace API.DTOs.ProjectDtos
{
    public class ListTaskUpsertRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
    }
}
