using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPShowCase01.Examples
{
    public interface IExample
    {
        void Start();
        void Stop();
        bool IsFinished();
    }
}
