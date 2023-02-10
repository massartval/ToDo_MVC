using ToDo_MVC.Models.Entities;

namespace ToDo_MVC.Models.Repositories
{
    public interface IItemRepository
    {
        Item? GetById(int id);
        IEnumerable<Item> GetAll();
        Item Create(Item item);
        Item? Update(Item item);
        Item? Toggle(int id);
        Item? Delete(int id);
    }
}
