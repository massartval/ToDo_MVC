namespace ToDo_MVC.Models.Entities
{
    public class Item
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public override string ToString()
        {
            return $"item {((Id > 0) ? Id : "")} with title \"{Title}\" and status \"{(IsCompleted ? "completed" : "incomplete")}\".";
        }
    }
}
