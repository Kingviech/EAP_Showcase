using EAPShowCase01.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPShowCase01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing application, press q to end program...");
            IExample ex = new ApplicationSynchronous();

            ex.Start();
            while (!ex.IsFinished())
            {
                var key = Console.ReadKey();
                if (key.Equals(ConsoleKey.Q))
                    ex.Stop();
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
