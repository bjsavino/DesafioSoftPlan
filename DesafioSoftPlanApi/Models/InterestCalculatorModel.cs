using DesafioSoftPlanApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftPlanApi.Models
{
    public class InterestCalculatorModel : IInterestCalculatorModel
    {
        private readonly decimal FEE_VALUE = 0.01M;
        private readonly string PROJECT_REPOSITORY = "github.com.br";

        public decimal GetFeeValue()
        {
            return FEE_VALUE;
        }
        public decimal CalculateInterest(decimal initialValue, int period)
        {
            var finalValue = initialValue * Convert.ToDecimal(Math.Pow(1 + (double)FEE_VALUE, period));
            return Math.Round(finalValue, 2);
        }
        public string ShowMeCode()
        {
            return PROJECT_REPOSITORY;
        }
    }
}
