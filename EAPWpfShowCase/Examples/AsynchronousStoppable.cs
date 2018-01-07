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

        public int LongRunningTask(int input)
        {
            Thread.Sleep(input * 1000);
            return input * input;
        }

        public void LongRunningTaskCancelAsync()
        {
            isLongRunningTaskStopped = true;
        }

        public void LongRunningTaskAsync(int input)
        {
            Task.Run(() =>
            {
                isLongRunningTaskStopped = false;
                // After cancel, the current operation will be finished before returning
                for (int i = 0; i < input && !isLongRunningTaskStopped; i++)
                    Thread.Sleep(1000);

                int result = -1;
                if(!isLongRunningTaskStopped)
                    result = input * input;

                LongRunningTaskCompleted.Invoke(this, new LongRunningTaskCompletedEventArgs(result, null, isLongRunningTaskStopped, null));
            });
        }
    }
}
