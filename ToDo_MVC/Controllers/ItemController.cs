using Microsoft.AspNetCore.Mvc;
using ToDo_MVC.Models.Entities;
using ToDo_MVC.Models.Forms;
using ToDo_MVC.Models.Repositories;
using ToDo_MVC.Tools;

namespace ToDo_MVC.Controllers
{
    [TypeFilter(typeof(ExceptionFilter))]
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;
        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        // GET: ItemController
        public ActionResult Index()
        {
            IEnumerable<Item> items = _repository.GetAll();
            return View(items);
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            Item? item = _repository.GetById(id);
            if (item is not null) 
                return View(item);
            else
                return RedirectToAction(nameof(Index));
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateItem form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Item? item = _repository.Create(form.MapItem());
            if (item is not null)
            {
                Console.WriteLine("Created " + item.ToString());
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(form);
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            Item? item = _repository.GetById(id);
            if (item is not null)
            {
                UpdateItem form = item.MapUpdateForm();
                return View(form);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // PUT: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateItem form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Item? item = _repository.Update(form.MapItem());
            if (item is not null)
            {
                Console.WriteLine("Updated " + item.ToString());
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(form);
            }
        }

        // POST : ItemController/Toggle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toggle(int id, ToggleItem form)
        {
            Item? item = _repository.Toggle(id);
            if (item is not null)
            {
                Console.WriteLine("Toggled " + item.ToString());
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(form);
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            Item? item = _repository.GetById(id);
            if (item is not null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Item? item = _repository.Delete(id);
            if (item is not null)
            {
                Console.WriteLine("Deleted " + item.ToString());
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(collection);
            }
        }
    }
}
