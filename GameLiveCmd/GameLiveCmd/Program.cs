using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLiveCmd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cglr = new ConsoleGameOfLiveRealisator();
            cglr.WriteFirstGeneration();
            Console.Read();
        }

        public interface IGameOfLiveRealisator
        {
            void WriteLiveDot();
            void WriteDeadDot();
        }

        public class ConsoleGameOfLiveRealisator : IGameOfLiveRealisator
        {
            private const string LiveDotChar = "|-|";
            private const string DeadDotChar = "| |";

            public void WriteFirstGeneration()
            {
                var grid = new byte[20, 20];
                grid = MakeGrid(grid);
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
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

            private byte[,] MakeGrid(byte[,] grid)
            {
                var rnd = new Random(DateTime.Now.Second);
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        grid[i, j] = (byte) rnd.Next(2);
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
}
