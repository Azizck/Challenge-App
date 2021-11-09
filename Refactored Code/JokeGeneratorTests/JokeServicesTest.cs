using ConsoleApp1;
using JokeGenerator;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JokeGeneratorTests
{
    public class JokeServicesTest
    {
        [Fact]
        public async Task GetJokesAsync_should_return_jokes()
        {
            var jokeService = new JokeService(ApplicationEndPoints.JOKES_URL);

            var jokes = await jokeService.GetJokesAsync(3);

            Assert.Equal(3, jokes.Count);
        }
      


    }
}
