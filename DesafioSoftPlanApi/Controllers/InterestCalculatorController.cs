using DesafioSoftPlanApi.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftPlanApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterestCalculatorController : ControllerBase
    {
        IInterestCalculatorModel _interestCalculatorModel;
        public InterestCalculatorController(IInterestCalculatorModel interestCalculatorModel)
        {
            this._interestCalculatorModel = interestCalculatorModel;
        }

        [HttpGet]
        [Route("taxaJuros")]
        public decimal GetFee()
        {
            return _interestCalculatorModel.GetFeeValue();
        }

        [HttpGet]
        [Route("calculaJuros")]
        public decimal InterestCalcutate([FromQuery] decimal valorinicial, [FromQuery] int meses)
        {
            return _interestCalculatorModel.CalculateInterest(valorinicial, meses);
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return _interestCalculatorModel.ShowMeCode();
        }
    }
}


