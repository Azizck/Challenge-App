using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JokeGenerator
{
    public class Presenter
    {
        private ConsolePrinter printer { get; }
        public Presenter()
        {
            printer = new ConsolePrinter();
        }

        public char PresentWelcomeMessage()
        {
            printer.Value("Welcome to Joke Generator \nPlease Type ? to get instructions.").ToString();
            return Console.ReadKey().KeyChar;
        }
        public char PresentOptions()
        {
            char key = '-';
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                printer.Value("\nPress c to get categories \nPress r to get random jokes").ToString();
                key = Console.ReadKey().KeyChar;
                Char[] validChars = { 'R', 'r', 'C', 'c' };
                if (!validChars.Contains(key))
                {
                    printer.Value("\nYou have entered invalid input, please try again").ToString();
                    isInvalidInput = true;
                }
            } while (isInvalidInput);
            return key;
        }

        public int PromptForJokeNumbers()
        {
            bool isInvalidInput;
            int number;
            do
            {
                isInvalidInput = false;
                printer.Value("\nPlease enter the number of jokes (1-9) and press Enter").ToString();
                var idAsString = Console.ReadLine();

                if (!InputValidator.IsJokeNumberValid(idAsString))
                {
                    printer.Value("You have entered invalid input, please try again").ToString();
                    isInvalidInput = true;
                }
                Int32.TryParse(idAsString,out number);
            }
            while (isInvalidInput);
            return number;
        }


        public void DisplayCategories(List<Category> categories)
        {
            printer.Value("\nCategories:").ToString();
            categories.ForEach(e => printer.Value($"ID:{e.Id} Name: {e.Value}").ToString());
        }
        public void DisplayJokes(List<Joke> jokes)
        {
            printer.Value("\nJokes:").ToString();
            jokes.ForEach(e => printer.Value(e.Value).ToString());
        }
        public char PromptForIsCategoryJoke()
        {
            char key;
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                printer.Value("Would you like to specify a category y/n?").ToString();
                key = Console.ReadKey().KeyChar;
                if (!Char.IsLetter(key))
                {
                    printer.Value("\nYou have entered invalid input, please try again").ToString();
                    isInvalidInput = true;
                }
            } while (isInvalidInput);
            return key;
        }
        public int PromptForCategoryId(int categoryLength)
        {
            int number;
            bool isInvalidInput;
            do
            {
                isInvalidInput = false;
                printer.Value("\nPlease enter the category Id and Press Enter").ToString();
                var idAsString = Console.ReadLine();
                if (!InputValidator.IsCategoryIdValid(idAsString,categoryLength))
                {
                    printer.Value("\nYou have entered invalid input, please try again").ToString();
                    isInvalidInput = true;
                }
                Int32.TryParse(idAsString, out number);

            } while (isInvalidInput);

            return number;
        }
        public char PromptForShouldContinue()
        {
            printer.Value("\nPress y to start again").ToString();
            return Console.ReadKey().KeyChar;
        }
    }
}
