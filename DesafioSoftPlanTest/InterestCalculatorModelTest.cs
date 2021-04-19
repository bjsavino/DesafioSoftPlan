using DesafioSoftPlanApi.Models;
using System;
using Xunit;

namespace DesafioSoftPlanTest
{
    public class InterestCalculatorModelTest
    {
        [Fact]
        public void ReturnStringNotNullWhenRequestShowMeCode()
        {
            InterestCalculatorModel icModel = new InterestCalculatorModel();
            var result = icModel.ShowMeCode();

            Assert.NotNull(result);
            Assert.IsType<String>(result);
        }

        [Fact]
        public void ReturnSpecifiedValueOfFeeWhenRequestGetFeeValue()
        {
            InterestCalculatorModel icModel = new InterestCalculatorModel();
            
            var result = icModel.GetFeeValue();

            Assert.Equal(0.01M,result);
            Assert.IsType<decimal>(result);
        }

        [Theory]
        [InlineData(100,5,105.10)]
        [InlineData(1000, 12, 1126.83)]
        public void ReturnInterestValueWhenRequestCalculateInterest(decimal initialValue, int period, decimal expectedValue)
        {
            InterestCalculatorModel icModel = new InterestCalculatorModel();

            var result = icModel.CalculateInterest(initialValue, period);

            Assert.Equal(expectedValue, result);
            Assert.IsType<decimal>(result);
        }
    }
}
