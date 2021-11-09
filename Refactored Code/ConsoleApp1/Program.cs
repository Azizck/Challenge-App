using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JokeGenerator;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
      
        static async Task Main(string[] args)
        {
            var categoryService = new CategoryService(ApplicationEndPoints.CATEGORY);
            var categories = await categoryService.GetCategories();
            var jokeService = new JokeService(ApplicationEndPoints.JOKES_URL);
            Presenter presenter = new Presenter();
            char key;
            List<Joke> jokes = new List<Joke>();

            presenter.PresentWelcomeMessage();

            bool keepGoing = true;
            do
            {
                key = presenter.PresentOptions();

                if (key == 'c')
                {

                    presenter.DisplayCategories(categories);
                }


                if (key == 'r')
                {

                    int jokeNumber = presenter.PromptForJokeNumbers();
                    key = presenter.PromptForIsCategoryJoke();

                    if (key == 'y')
                    {
                        int categoryId = presenter.PromptForCategoryId(categories.Count);
                        jokes = await jokeService.GetJokesAsync(jokeNumber, categories.FirstOrDefault(elem => elem.Id == categoryId));
                    }

                    else
                    {
                        jokes = await jokeService.GetJokesAsync(jokeNumber);

                    }

                    presenter.DisplayJokes(jokes);

                    key = presenter.PromptForShouldContinue();

                    if ( !(key == 'y' || key == 'Y'))
                    {
                        keepGoing = false;
                    }
                }

           

            }
            while (keepGoing);
           
        }


    }
}
