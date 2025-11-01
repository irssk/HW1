using System;
using System.Linq;

namespace Calculator
{
    public class StatisticsCalculator : Calculator
    {
        public double Mean(double[] data)
        {
            if (data == null || data.Length == 0)
                throw new InvalidOperationException("Помилка: масив даних порожній.");

            LastResult = data.Average();
            return LastResult;
        }

        public double Median(double[] data)
        {
            if (data == null || data.Length == 0)
                throw new InvalidOperationException("Помилка: масив даних порожній.");

            var sorted = data.OrderBy(x => x).ToArray();
            int n = sorted.Length;

            LastResult = (n % 2 == 0)
                ? (sorted[n / 2 - 1] + sorted[n / 2]) / 2
                : sorted[n / 2];

            return LastResult;
        }

        public double StdDev(double[] data)
        {
            if (data == null || data.Length == 0)
                throw new InvalidOperationException("Помилка: масив даних порожній.");

            double mean = data.Average();
            LastResult = Math.Sqrt(data.Average(v => Math.Pow(v - mean, 2)));
            return LastResult;
        }
    }
}
