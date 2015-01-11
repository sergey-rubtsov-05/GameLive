using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class GameOfLifeMainMethodsMultiThread: GameOfLifeParameters, IGameOfLifeMainMethods
    {
        public byte[,] CalculateNextGeneration(byte[,] grid)
        {
            var newGrid = (byte[,])grid.Clone();
            for (int i = 0; i < GridSize; i++)
            {
                Parallel.For(0, GridSize, ctr =>
                {
                    var countNeigbors = CountNeigbors(grid, i, ctr);
                    if (grid[i, ctr] == 1)
                    {
                        if (countNeigbors < 2 || countNeigbors > 3)
                            newGrid[i, ctr] = 0;
                    }
                    else
                    {
                        if (countNeigbors == 3)
                        {
                            newGrid[i, ctr] = 1;
                        }
                    }
                });
            }
            return newGrid;
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
    }
}
