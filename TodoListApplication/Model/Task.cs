namespace TodoListApplication.Model
{
    public class ToDoTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
    }
}
