namespace LR3.Calculation
{
    public interface ICalculationService
    {
        double Sum(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
        double Pow(double x, double y);
    }
}
