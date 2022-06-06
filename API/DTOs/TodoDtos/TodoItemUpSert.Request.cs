namespace API.DTOs.Todos
{
    public class TodoItemUpSertRequest
    {
        public string Content { get; set; }
        public bool IsDone { get; set; } = false;
        public int TodoId { get; set; }
    }
}
