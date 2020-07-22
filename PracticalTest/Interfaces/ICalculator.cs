using System.Threading.Tasks;

namespace PracticalTest.Interfaces
{
    public interface ICalculator
    {
        int Calculate(int leftNumber, int rightNumber, char operatorUsed);
    }
}