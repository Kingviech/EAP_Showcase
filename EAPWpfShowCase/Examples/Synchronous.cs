using System.Threading;

namespace EAPWpfShowCase.Examples
{
    public class Synchronous
    {
        public int LongRunningTask(int input)
        {
            Thread.Sleep(input * 1000);
            return input * input;
        }
    }
}