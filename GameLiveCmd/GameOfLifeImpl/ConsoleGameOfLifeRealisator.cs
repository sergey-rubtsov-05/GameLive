using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class ConsoleGameOfLifeRealisator : IGameOfLifeRealisator
    {
        private const string LiveDotChar = "|-|";
        private const string DeadDotChar = "| |";


        private const int GridSize = 20;

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

        public byte[,] CalculateNextGeneration(byte[,] grid)
        {
            var newGrid = grid;
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {

                    var countNeigbors = CountNeigbors(grid, i, j);
                    if (grid[i, j] == 1)
                    {
                        if (countNeigbors < 2 || countNeigbors > 3)
                            newGrid[i, j] = 0;
                    }
                    else
                    {
                        if (countNeigbors == 3)
                        {
                            newGrid[i, j] = 1;
                        }
                    }
                }
            }
            return newGrid;
        }

        private int CountNeigbors(byte[,] grid, int i, int j)
        {
            int countNeigbors = 0;
            try
            {
                if (grid[i, j + 1] == 1)
                    countNeigbors++;
            }
            catch
            { }
            try
            {
                if (grid[i + 1, j] == 1)
                    countNeigbors++;
            }
            catch
            {
            }
            try
            {
                if (grid[i - 1, j] == 1)
                    countNeigbors++;
            }
            catch
            {
            }
            try
            {
                if (grid[i, j - 1] == 1)
                    countNeigbors++;
            }
            catch
            {
            }
            try
            {
                if (grid[i + 1, j + 1] == 1)
                    countNeigbors++;
            }
            catch
            {
            }
            try
            {
                if (grid[i - 1, j - 1] == 1)
                    countNeigbors++;
            }
            catch { }
            try
            {
                if (grid[i + 1, j - 1] == 1)
                    countNeigbors++;
            }
            catch { }
            try
            {
                if (grid[i - 1, j + 1] == 1)
                    countNeigbors++;
            }
            catch { }
            return countNeigbors;
        }

        public byte[,] MakeRandomGeneration()
        {
            var grid = new byte[GridSize, GridSize];
            var rnd = new Random(DateTime.Now.Second);
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    grid[i, j] = (byte)rnd.Next(2);
                }
            }
            return grid;
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
