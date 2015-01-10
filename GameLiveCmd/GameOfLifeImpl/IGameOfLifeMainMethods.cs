using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public interface IGameOfLifeMainMethods
    {
        byte[,] CalculateNextGeneration(byte[,] grid);
        byte[,] MakeRandomGeneration();
    }
}
