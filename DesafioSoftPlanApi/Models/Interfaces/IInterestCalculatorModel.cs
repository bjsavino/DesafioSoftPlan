namespace DesafioSoftPlanApi.Models.Interfaces
{
    public interface IInterestCalculatorModel
    {
        decimal CalculateInterest(decimal initialValue, int period);
        decimal GetFeeValue();
        string ShowMeCode();
    }
}