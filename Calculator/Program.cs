using System;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Виберіть тип калькулятора:");
                Console.WriteLine("1 - Базовий");
                Console.WriteLine("2 - Науковий");
                Console.WriteLine("3 - Програмістський");
                Console.WriteLine("4 - Статистичний");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                Calculator calc = choice switch
                {
                    "1" => new Calculator(),
                    "2" => new ScientificCalculator(),
                    "3" => new ProgrammerCalculator(),
                    "4" => new StatisticsCalculator(),
                    "0" => null,
                    _ => null
                };

                if (choice == "0")
                {
                    Console.WriteLine("Вихід із програми...");
                    break;
                }

                if (calc == null)
                {
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.\n");
                    continue;
                }

                try
                {
                    PerformOperations(calc);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}\n");
                }
            }
        }

        static void PerformOperations(Calculator calc)
        {
            if (calc is ScientificCalculator sci)
            {
                Console.WriteLine("Доступні операції: Add, Subtract, Multiply, Divide, Pow, Sqrt, Sin, Cos");
                Console.Write("Введіть операцію: ");
                string op = Console.ReadLine();

                double a = 0, b = 0;
                if (op == "Sqrt" || op == "Sin" || op == "Cos")
                {
                    Console.Write("Введіть число: ");
                    a = double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.Write("Введіть перше число: ");
                    a = double.Parse(Console.ReadLine());
                    Console.Write("Введіть друге число: ");
                    b = double.Parse(Console.ReadLine());
                }

                double result = op switch
                {
                    "Add" => sci.Add(a, b),
                    "Subtract" => sci.Subtract(a, b),
                    "Multiply" => sci.Multiply(a, b),
                    "Divide" => sci.Divide(a, b),
                    "Pow" => sci.Pow(a, b),
                    "Sqrt" => sci.Sqrt(a),
                    "Sin" => sci.Sin(a),
                    "Cos" => sci.Cos(a),
                    _ => throw new InvalidOperationException("Невідома операція")
                };

                Console.WriteLine($"Результат: {result}");
            }
            else if (calc is ProgrammerCalculator prog)
            {
                Console.WriteLine("Доступні операції: Add, Subtract, Multiply, Divide, And, Or, Xor, ToBinary, ToHex");
                Console.Write("Введіть операцію: ");
                string op = Console.ReadLine();

                if (op == "ToBinary" || op == "ToHex")
                {
                    Console.Write("Введіть ціле число: ");
                    int x = int.Parse(Console.ReadLine());
                    string res = op == "ToBinary" ? prog.ToBinary(x) : prog.ToHex(x);
                    Console.WriteLine($"Результат: {res}");
                }
                else
                {
                    Console.Write("Введіть перше число: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Введіть друге число: ");
                    int b = int.Parse(Console.ReadLine());

                    double result = op switch
                    {
                        "Add" => prog.Add(a, b),
                        "Subtract" => prog.Subtract(a, b),
                        "Multiply" => prog.Multiply(a, b),
                        "Divide" => prog.Divide(a, b),
                        "And" => prog.And(a, b),
                        "Or" => prog.Or(a, b),
                        "Xor" => prog.Xor(a, b),
                        _ => throw new InvalidOperationException("Невідома операція")
                    };

                    Console.WriteLine($"Результат: {result}");
                }
            }
            else if (calc is StatisticsCalculator stat)
            {
                Console.WriteLine("Доступні операції: Mean, Median, StdDev");
                Console.Write("Введіть операцію: ");
                string op = Console.ReadLine();

                Console.Write("Введіть числа через пропуск: ");
                double[] data = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                double result = op switch
                {
                    "Mean" => stat.Mean(data),
                    "Median" => stat.Median(data),
                    "StdDev" => stat.StdDev(data),
                    _ => throw new InvalidOperationException("Невідома операція")
                };

                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Доступні операції: Add, Subtract, Multiply, Divide");
                Console.Write("Введіть операцію: ");
                string op = Console.ReadLine();

                Console.Write("Введіть перше число: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введіть друге число: ");
                double b = double.Parse(Console.ReadLine());

                double result = op switch
                {
                    "Add" => calc.Add(a, b),
                    "Subtract" => calc.Subtract(a, b),
                    "Multiply" => calc.Multiply(a, b),
                    "Divide" => calc.Divide(a, b),
                    _ => throw new InvalidOperationException("Невідома операція")
                };

                Console.WriteLine($"Результат: {result}");
            }

            Console.WriteLine($"LastResult: {calc.LastResult}\n");
        }
    }
}
