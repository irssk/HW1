using System;

namespace Calculator
{
    public class ScientificCalculator : Calculator
    {
        public double Pow(double x, double y)
        {
            LastResult = Math.Pow(x, y);
            return LastResult;
        }

        public double Sqrt(double x)
        {
            if (x < 0)
                throw new InvalidOperationException("Помилка: не можна витягти коріння з негативного числа.");
            LastResult = Math.Sqrt(x);
            return LastResult;
        }

        public double Sin(double x)
        {
            LastResult = Math.Sin(x);
            return LastResult;
        }

        public double Cos(double x)
        {
            LastResult = Math.Cos(x);
            return LastResult;
        }

        public override double Divide(double a, double b)
        {
            Console.WriteLine($"[ScientificCalculator] Ділення {a} / {b}");
            return base.Divide(a, b);
        }
    }
}
