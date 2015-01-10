using System;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class GameOfLifeMainMethods : GameOfLifeParameters, IGameOfLifeMainMethods
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
                //for (int j = 0; j < GridSize; j++)
                //{

                //    var countNeigbors = CountNeigbors(grid, i, j);
                //    if (grid[i, j] == 1)
                //    {
                //        if (countNeigbors < 2 || countNeigbors > 3)
                //            newGrid[i, j] = 0;
                //    }
                //    else
                //    {
                //        if (countNeigbors == 3)
                //        {
                //            newGrid[i, j] = 1;
                //        }
                //    }
                //}
            }
            return newGrid;
        }

        private int CountNeigbors(byte[,] grid, int i, int j)
        {
            int countNeigbors = 0;
            if (IsExistsThisRange(i, j+1))
            {
                if (grid[i, j + 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i+1, j))
            {
                if (grid[i + 1, j] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i-1,j))
            {
                if (grid[i - 1, j] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i, j-1))
            {
                if (grid[i, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i+1,j+1))
            {
                if (grid[i + 1, j + 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i-1,j-1))
            {
                if (grid[i - 1, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i+1, j-1))
            {
                if (grid[i + 1, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i-1,j+1))
            {
                if (grid[i - 1, j + 1] == 1)
                    countNeigbors++;
            }
            return countNeigbors;
        }

        private bool IsExistsThisRange(int i, int j)
        {
            return !(i >= GridSize || i < 0 || j >= GridSize || j < 0);
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
