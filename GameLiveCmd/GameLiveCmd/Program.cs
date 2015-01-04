using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeImpl;

namespace GameLiveCmd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            var cglr = new ConsoleGameOfLifeRealisator();
            var grid = cglr.MakeRandomGeneration();
            cglr.WriteGeneration(grid);
            for (int i = 0; i < 5; i++)
            {
                grid = cglr.CalculateNextGeneration(grid);
                Console.WriteLine();
                cglr.WriteGeneration(grid);
                Console.WriteLine(DateTime.Now);
            }
            Console.Read();
        }
    }
}
