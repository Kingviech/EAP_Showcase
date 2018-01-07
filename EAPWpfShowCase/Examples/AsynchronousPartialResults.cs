using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EAPWpfShowCase.Examples
{
    public delegate void LongRunningTaskPartialResultProgressChangedHandler(object sender, PartialResultProgressChangedEventArgs e);

    public class PartialResultProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public PartialResultProgressChangedEventArgs(int progressPercentage, object userState) : base(progressPercentage, userState)
        {
        }

        public PartialResultProgressChangedEventArgs(int partialResult, int progressPercentage, object userState) : base(progressPercentage, userState)
        {
            PartialResult = partialResult;
        }

        public int PartialResult { get; }
    }

    public class AsynchronousPartialResults
    {
        public event LongRunningTaskCompletedEventHandler LongRunningTaskCompleted;
        public event LongRunningTaskPartialResultProgressChangedHandler LongRunningTaskProgressChanged;


        public void LongRunningTaskAsync(int input)
        {
            Task.Run(() =>
            {
                // Signal progress changes to the clients
                int result = input;
                for (int i = 0; i < input; i++)
                {
                    result *= input;
                    Thread.Sleep(1000);

                    // Calculate progress and fire progress changed event
                    int curProgress = (int)Math.Round((float)(i + 1) / input * 100, 0);
                    var progressEventArgs = new PartialResultProgressChangedEventArgs(result, curProgress, null);
                    LongRunningTaskProgressChanged.Invoke(this, progressEventArgs);
                }

                LongRunningTaskCompleted.Invoke(this, new LongRunningTaskCompletedEventArgs(result));
            });
        }
    }
}
