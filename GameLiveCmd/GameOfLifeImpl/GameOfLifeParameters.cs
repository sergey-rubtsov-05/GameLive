using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class GameOfLifeParameters
    {
        public const int GridSize = 40;


        protected int CountNeigbors(byte[,] grid, int i, int j)
        {
            int countNeigbors = 0;
            if (IsExistsThisRange(i, j + 1))
            {
                if (grid[i, j + 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i + 1, j))
            {
                if (grid[i + 1, j] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i - 1, j))
            {
                if (grid[i - 1, j] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i, j - 1))
            {
                if (grid[i, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i + 1, j + 1))
            {
                if (grid[i + 1, j + 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i - 1, j - 1))
            {
                if (grid[i - 1, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i + 1, j - 1))
            {
                if (grid[i + 1, j - 1] == 1)
                    countNeigbors++;
            }
            if (IsExistsThisRange(i - 1, j + 1))
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
    }
}
