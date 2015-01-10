using System;

namespace GameOfLifeImpl
{
    public class ConsoleGameOfLifeRealisator : GameOfLifeParameters
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
        }

        private void WriteLiveDot()
        {
            Console.Write(LiveDotChar);
        }

        private void WriteDeadDot()
        {
            Console.Write(DeadDotChar);
        }
    }
}
