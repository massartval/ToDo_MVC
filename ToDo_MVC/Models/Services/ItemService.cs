using System.Text.Json;
using ToDo_MVC.Models.Entities;
using ToDo_MVC.Models.Repositories;

namespace ToDo_MVC.Models.Services
{
    public class ItemService : IItemRepository
    {
        private readonly IHttpClientFactory _factory;
        public ItemService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<Item> GetAll()
        {
            using (HttpClient client = _factory.CreateClient("Api")) 
            {
                using (HttpResponseMessage message = client.GetAsync("item").Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item[]>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }
        public Item? GetById(int id)
        {
            using (HttpClient client = _factory.CreateClient("Api"))
            {
                using (HttpResponseMessage message = client.GetAsync($"item/{id}").Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
        }

        public Item Create(Item item)
        {
            using (HttpClient client = _factory.CreateClient("Api"))
            {
                JsonContent content = JsonContent.Create(item);
                using (HttpResponseMessage message = client.PostAsync("item", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }

        public Item? Update(Item item)
        {
            using (HttpClient client = _factory.CreateClient("Api"))
            {
                JsonContent content = JsonContent.Create(item);
                using (HttpResponseMessage message = client.PutAsync($"item/{item.Id}", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }

        public Item? Toggle(int id)
        {
            using (HttpClient client = _factory.CreateClient("Api"))
            {
                JsonContent content = JsonContent.Create("");
                using (HttpResponseMessage message = client.PutAsync($"item/toggle/{id}", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }

        public Item? Delete(int id)
        {
            using (HttpClient client = _factory.CreateClient("Api"))
            {
                using (HttpResponseMessage message = client.DeleteAsync($"item/{id}").Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<Item>(json, options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }
    }
}
