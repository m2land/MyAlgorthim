using ConsoleApplication1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0 % 10);

            var input = args[0];
            var target = int.Parse(args[1]);

            var charArray = input.Split(new char[] { ',', ' ' });

            var orderChar = new List<int>();

            foreach (var c in charArray)
            {
                orderChar.Add(int.Parse(c));

            }

            Algorithm.MaxIntInCharCombination(orderChar, target);
        }
    }
}
