using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemizer
{
    public partial class Randomization
    {
        void WriteToRom(int address, byte value)
        {
            if(address == 0)
            {
                Debugger.Break();
            }
            ROM_DATA[address] = value;
        }
    }
}
