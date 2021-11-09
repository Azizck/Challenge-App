using JokeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JokeGeneratorTests
{
    public class TestInputValidator
    {
        [Theory]
        [InlineData("11",10)]
        [InlineData("-1", 10)]
        [InlineData("0", 10)]
        public void  InvalidCategoryId_should_return_false(string categoryIdStr, int categoryListLength)
        {
            var result = InputValidator.IsCategoryIdValid(categoryIdStr, categoryListLength);
            Assert.True(false == result);
        }

        [Theory]
        [InlineData("10", 10)]
        [InlineData("5", 10)]
        [InlineData("1", 10)]
        public void ValidCategoryId_should_return_true(string categoryIdStr, int categoryListLength)
        {
            var result = InputValidator.IsCategoryIdValid(categoryIdStr, categoryListLength);
            Assert.True(true == result);
        }


        [Theory]
        [InlineData("cfe", 10)]
        [InlineData("-g24", 10)]
        [InlineData("!", 10)]
        public void InvalidDataType_should_return_false(string categoryIdStr, int categoryListLength)
        {
            var result = InputValidator.IsCategoryIdValid(categoryIdStr, categoryListLength);
            Assert.True(false == result);
        }





        [Theory]
        [InlineData("10")]
        [InlineData("0")]
        [InlineData("-1")]
        public void OutOfRangeNumberOfJokes_should_return_false(string numberOfJokes)
        {
            var result = InputValidator.IsJokeNumberValid(numberOfJokes);
            Assert.True(false == result);
        }
        [Theory]
        [InlineData("9")]
        [InlineData("1")]
        public void InfRangeNumberOfJokes_should_return_true(string numberOfJokes)
        {
            var result = InputValidator.IsJokeNumberValid(numberOfJokes);
            Assert.True(true == result);
        }


        [Theory]
        [InlineData("wef")]
        [InlineData("-?c3")]
        public void InvalidDataTypeNumberOfJokes_should_return_false(string numberOfJokes)
        {
            var result = InputValidator.IsJokeNumberValid(numberOfJokes);
            Assert.True(false == result);
        }

    }
}
