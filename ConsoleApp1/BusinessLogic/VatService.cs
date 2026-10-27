namespace ConsoleApp1.Vat
{
    public class VatService
    {
        public double vatNetno(double a, double p)
        {
            return a * (1 + p / 100);
        }
        public double vatBez(double a, double p)
        {
            return a / (1 + p / 100);
        }
    }
}
