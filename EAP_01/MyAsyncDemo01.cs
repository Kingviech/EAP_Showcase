using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EAP_01
{
    public class MyAsyncDemo01
    {
        public int LongRunningTask(int input)
        {
            Thread.Sleep(input);
            return input;
        }

    }
}
