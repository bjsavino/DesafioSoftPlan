using DesafioSoftPlanApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesafioSoftPlanTest
{
    public class InterestCalculatorIntegrationTest
    {
        private readonly WebApplicationFactory<DesafioSoftPlanApi.Startup> _factory;

        public InterestCalculatorIntegrationTest()
        {
            _factory = new WebApplicationFactory<DesafioSoftPlanApi.Startup>();
        }

        [Theory]
        [InlineData("interestCalculator/taxaJuros")]
        [InlineData("interestCalculator/calculaJuros")]
        [InlineData("interestCalculator/showmethecode")]
        public async Task EndPointReturnSuccess(string endpoint)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetFeeValue()
        {
            
            var client = _factory.CreateClient();

            var response = await client.GetAsync("interestCalculator/taxaJuros");
            var valueString = await response.Content.ReadAsStringAsync();

            InterestCalculatorModel icModel = new InterestCalculatorModel();

            response.EnsureSuccessStatusCode();

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider = new CultureInfo("en-US");

            Assert.Equal(icModel.GetFeeValue(), Decimal.Parse(valueString,style,provider));
        }

        [Fact]
        public async Task CalculateInterest()
        {

            var client = _factory.CreateClient();

            var response = await client.GetAsync("interestCalculator/calculaJuros?valorinicial=100&meses=5");
            var valueString = await response.Content.ReadAsStringAsync();

            InterestCalculatorModel icModel = new InterestCalculatorModel();

            response.EnsureSuccessStatusCode();
            
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo provider =new CultureInfo("en-US");

            Console.WriteLine(response);
            Assert.Equal(icModel.CalculateInterest(100,5), Decimal.Parse(valueString,style,provider));
        }

        [Fact]
        public async Task ShowMeTheCode()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("interestCalculator/showmethecode");
            var valueString = await response.Content.ReadAsStringAsync();

            InterestCalculatorModel icModel = new InterestCalculatorModel();

            response.EnsureSuccessStatusCode();

            Assert.Equal(icModel.ShowMeCode(), valueString);
        }
    }
}
