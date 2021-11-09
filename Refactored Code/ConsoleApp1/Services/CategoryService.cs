using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace JokeGenerator
{
    public class CategoryService : HttpSerivce, ICategoryService
    {
        public CategoryService(string baseUri) : base(baseUri)
        {
        }
        public async Task<List<Category>> GetCategories()
        {
            var httpResponse = await _client.GetAsync("");
            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Error in fetching categories");
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(content).Select((text, index) => new Category { Value = text, Id = ++index }).ToList();
        }
    }
}
