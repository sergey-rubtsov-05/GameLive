using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class ConsoleGameOfLifeRealisator : GameOfLifeMainMethods, IGameOfLifeRealisator
    {
        private const string LiveDotChar = "|-|";
        private const string DeadDotChar = "| |";

        public void WriteGeneration(byte[,] grid)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        WriteLiveDot();
                    }
                    else
                    {
                        WriteDeadDot();
                    }
                }
                Console.WriteLine();
            }
            CalculateNextGeneration(grid);
        }

        public void WriteLiveDot()
        {
            Console.Write(LiveDotChar);
        }

        public void WriteDeadDot()
        {
            Console.Write(DeadDotChar);
        }
    }
}
