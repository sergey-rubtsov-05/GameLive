using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    interface IGameOfLifeRealisator
    {
        void WriteLiveDot();
        void WriteDeadDot();
        void WriteGeneration(byte[,] grid);
    }
}
