using System;

namespace Calculator
{
    public class ProgrammerCalculator : Calculator
    {
        public string ToBinary(int value) => Convert.ToString(value, 2);
        public string ToHex(int value) => Convert.ToString(value, 16).ToUpper();

        public int And(int a, int b)
        {
            LastResult = a & b;
            return (int)LastResult;
        }

        public int Or(int a, int b)
        {
            LastResult = a | b;
            return (int)LastResult;
        }

        public int Xor(int a, int b)
        {
            LastResult = a ^ b;
            return (int)LastResult;
        }
    }
