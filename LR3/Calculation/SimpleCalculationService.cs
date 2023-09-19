namespace LR3.Calculation
{
    public class SimpleCalculationService : ICalculationService
    {
        public double Sum(double x, double y) => x + y;

        public double Subtract(double x, double y) => x - y;

        public double Multiply(double x, double y) => x * y;

        public double Divide(double x, double y) => x / y;

        public double Pow(double x, double y) => Math.Pow(x, y);
    }
}
