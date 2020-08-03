using System;

namespace PracticalTest.Common.Utils
{
    public static class Calculator
    {
        public static int Caculate(int left, int right, char operatorUsed)
        {
            if(right == 0 && operatorUsed == '/')
                throw new AutomationException("Divided by 0 is a invalid calculation.");

            switch (operatorUsed)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
                default:
                    throw new Exception($"{operatorUsed} is not a valid operator type.");
            }
        }
    }
}