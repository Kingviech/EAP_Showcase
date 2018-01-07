using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberCalculation
{
    /// <summary>
    /// Implementation from https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern
    /// </summary>
    public class PrimeNumberCalculator
    {
        public bool IsPrime(long n)
        {
            if (n < 1) throw new ArgumentException("Given number to check must be greater or equal to 1.", nameof(n));

            if (n == 1)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            long sqrt = (long)Math.Sqrt(n);

            for (long i = 3; i <= sqrt; i += 2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;            
        }
    }
}
