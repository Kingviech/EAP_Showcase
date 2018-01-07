using System.Threading;

namespace EAPWpfShowCase.Examples
{
    public class Synchronous
    {
        public int LongRunningTask(int input)
        {
            int result = input;
            for (int i = 0; i < input; i++)
            {
                // Long running calculation...
                result *= input;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
}