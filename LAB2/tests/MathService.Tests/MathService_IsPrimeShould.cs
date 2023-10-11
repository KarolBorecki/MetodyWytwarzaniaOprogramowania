using Xunit;
using Math.Services;

namespace Math.UnitTests.Services
{
    public class MathService_IsPrimeShould
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            // arrange
            var mathService = new MathService();
            
            // act
            bool result = mathService.IsPrime(1);

            // assert
            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
         public void IsDivideableBy2_ForGivenNumber_ReturnsCorrect(int number, bool correctResult)
        {
            // arrange
            var mathService = new MathService();
            
            // act
            bool result = mathService.IsDivideableBy2(number);

            // assert
            Assert.Equal(correctResult, result);
        }
    }
}