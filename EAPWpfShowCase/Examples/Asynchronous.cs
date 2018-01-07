using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace EAPWpfShowCase.Examples
{
    public delegate void LongRunningTaskCompletedEventHandler(object sender, LongRunningTaskCompletedEventArgs e);

    public class Asynchronous
    {
        public event LongRunningTaskCompletedEventHandler LongRunningTaskCompleted;

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

        public void LongRunningTaskAsync(int input)
        {
            Task.Run(() =>
            {
                var result = LongRunningTask(input);
                LongRunningTaskCompleted.Invoke(this, new LongRunningTaskCompletedEventArgs(result));
            });
        }
    }

    public class LongRunningTaskCompletedEventArgs : AsyncCompletedEventArgs
    {
        public LongRunningTaskCompletedEventArgs(int result) : base(null, false, null)
        {
            Result = result;
        }

        public LongRunningTaskCompletedEventArgs(int result, Exception error, bool cancelled, object userState) : base(error, cancelled, userState)
        {
            Result = result;
        }

        public int Result { get; }
    }
}