using ConsoleApp1;
using JokeGenerator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JokeGeneratorTests
{
    public class CategoryServicesTest
    {
        [Fact]
        public async Task GetCategories_should_return_categories()
        {
            var categoryService = new CategoryService(ApplicationEndPoints.CATEGORY);

            var categories = await categoryService.GetCategories();

            Assert.True(categories.Count > 0);
        }




    }
}
