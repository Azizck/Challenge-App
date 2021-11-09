using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    public interface IJokeService
    {
        Task<List<Joke>> GetJokesAsync(int number);
        Task<List<Joke>> GetJokesAsync(int? number, Category category);
    }
}
