using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace JokeGenerator
{
    // prev name was JsonFeed
    public class JokeService : HttpSerivce, IJokeService
    {
        public JokeService(string baseUri) : base(baseUri)
        {
        }
        public async Task<List<Joke>> GetJokesAsync(int number = 1) => await RequestJokes("", number);
        public async Task<List<Joke>> GetJokesAsync(int? number, Category category)
        {
            var parameters = new Dictionary<string, string>
            {
              {"category",category.Value}
            };
            var request = "?" + string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
            return await RequestJokes(request,number ?? 1);
        }
        private async Task<List<Joke>> RequestJokes(string request,int number = 1)
        {
            var fetchJokesTasks = new List<Task<HttpResponseMessage>>();
            for (var i = 0; i < number; i++)
            {
                var response = _client.GetAsync(request);
                fetchJokesTasks.Add(response);
            }
            // start all tasks in parallel
            await Task.WhenAll(fetchJokesTasks);
            var jokes = fetchJokesTasks.ConvertAll(async httpResponseTask =>
            {
                var response = await httpResponseTask;
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error occured in fetching jokes");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Joke>(content);
            }).Select(e => e.Result).ToList();
            return jokes;
        }
    }
}
