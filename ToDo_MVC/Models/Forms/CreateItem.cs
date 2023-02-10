using System.ComponentModel.DataAnnotations;

namespace ToDo_MVC.Models.Forms
{
    public class CreateItem
    {
        [Required]
        public string Title { get; set; }
    }
}
