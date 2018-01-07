using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EAPWpfShowCase.Examples
{
    public class AsynchronousStoppable
    {
        public event LongRunningTaskCompletedEventHandler LongRunningTaskCompleted;
        private bool isLongRunningTaskStopped = false;

        public void LongRunningTaskCancelAsync()
        {
            isLongRunningTaskStopped = true;
        }

        public void LongRunningTaskAsync(int input)
        {
            Task.Run(() =>
            {
                isLongRunningTaskStopped = false;
                int result = input;
                // After cancel, the current operation will be finished before returning
                for (int i = 0; i < input && !isLongRunningTaskStopped; i++)
                {
                    result *= input;
                    Thread.Sleep(1000);
                }

                LongRunningTaskCompleted.Invoke(this, new LongRunningTaskCompletedEventArgs(result, null, isLongRunningTaskStopped, null));
            });
        }
    }
}
