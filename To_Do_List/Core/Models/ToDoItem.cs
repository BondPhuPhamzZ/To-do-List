namespace To_Do_List.Core.Models
{
    public class ToDoItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }

    }
}
