using System;

namespace PracticalTest.Common.Utils
{
    public static class Calculator
    {
        public static int Caculate(int left, int right, char operatorUsed)
        {
            switch (operatorUsed)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    if(right == 0)
                        throw new AutomationException("Divided by 0 on calculator is not allowed.");
                    return left / right;
                default:
                    throw new Exception($"{operatorUsed} is not a valid operator type on calculator.");
            }
        }
    }
}