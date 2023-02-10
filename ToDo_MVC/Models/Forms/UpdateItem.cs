using System.ComponentModel.DataAnnotations;

namespace ToDo_MVC.Models.Forms
{
    public class UpdateItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
