using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EAPWpfShowCase.Examples
{
    public class AsynchronousWithException
    {
        public event LongRunningTaskCompletedEventHandler LongRunningTaskCompleted;
        public int LongRunningTask(int input)
        {
            Thread.Sleep(input * 1000);
            throw new Exception("Oops, something bad happened");
            //return input * input;
        }

        public void LongRunningTaskAsync(int input)
        {
            Task.Run(() =>
            {
                int result = -1;
                Exception e = null;

                try
                {
                    result = LongRunningTask(input);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
                finally
                {
                    LongRunningTaskCompleted.Invoke(this, new LongRunningTaskCompletedEventArgs(result, e, false, null));
                }                
            });
        }
    }
}
