using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    public class InputValidator
    {



        public static bool IsJokeNumberValid(string numberOfJokes)
        {
            int number = -1;
            return !(Int32.TryParse(numberOfJokes, out number) == false || number < 1 || number > 9);

        }
        public static bool IsCategoryIdValid(string categoryId, int categoryListLength)
        {
            int number = -1;
            return !(Int32.TryParse(categoryId, out number) == false || number < 1 || number > categoryListLength);

        }


    }


}
