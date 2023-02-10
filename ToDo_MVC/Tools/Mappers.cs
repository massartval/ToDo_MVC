using ToDo_MVC.Models.Entities;
using ToDo_MVC.Models.Forms;

namespace ToDo_MVC.Tools
{
    internal static class Mappers
    {
        internal static Item MapItem(this CreateItem form)
        {
            return new Item()
            {
                Title = form.Title,
            };
        }

        internal static Item MapItem(this UpdateItem form)
        {
            return new Item()
            {
                Id = form.Id,
                Title = form.Title,
                IsCompleted = form.IsCompleted
            };
        }

        internal static UpdateItem MapUpdateForm(this Item item)
        {
            return new UpdateItem()
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
