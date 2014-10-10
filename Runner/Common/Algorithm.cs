using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Common
{
    public class Algorithm
    {
        public static int MaxIntInCharCombination(List<int> orderChar, int target)
        {

            orderChar.Sort();

            var parent = new List<int>();

            foreach (var i in orderChar)
            {

                if (i != 0)
                {
                    if (i > target)
                    {
                        return i;
                    }
                    else
                    {
                        parent.Add(i);
                    }
                }
            }

            foreach (var i in orderChar)
            {
                if (i != 0)
                {
                    return search(parent, orderChar, target);
                }
            }

            return 0;
        }

        static int search(List<int> parent, List<int> numberArray, int target)
        {
            var temp = new List<int>();
            foreach (var p in parent)
            {
                foreach (var i in numberArray)
                {

                    if (p * 10 + i > target)
                    {
                        return p * 10 + i;
                    }
                    else
                    {
                        temp.Add(p * 10 + i);
                    }
                }
            }
            return search(temp, numberArray, target);
        }


        public static int? MaxIntInCharCombinationV2(List<int> charList, int target)
        {
            var numberInEachPostion = SplitTheTargetIntoArray(target);
            return ListToInt(FindMaxInteger(charList, numberInEachPostion.ToList<int>()));
        }

        private static List<int> FindMaxInteger(List<int> charList, List<int> numberInEachPosition)
        {
            charList.Sort();
            var smallestNumberInCharList = charList.First<int>();
            var highestNumberInTarget = numberInEachPosition.First<int>();
            var HighestNumber = new List<int>();

            if (charList.Contains(highestNumberInTarget) && numberInEachPosition.Count() != 1) // Has a number equal the first number of target
            {
                var orginialCount = numberInEachPosition.Count();
                var firstNumber = numberInEachPosition[0];

                numberInEachPosition.RemoveAt(0);
                var innerResult = FindMaxInteger(charList, numberInEachPosition);
                if (innerResult.Count() >= orginialCount)
                {
                    for (var i = 0; i < orginialCount + 1; i++)
                    {
                        HighestNumber.Add(smallestNumberInCharList);
                    }
                }
                else
                {
                    HighestNumber.Add(firstNumber);
                    HighestNumber = HighestNumber.Concat<int>(innerResult).ToList<int>();
                }

                return HighestNumber;
            }

            try
            {
                int firstBiggerNumber = 0;
                firstBiggerNumber = charList.First<int>(number => number > highestNumberInTarget); // Has one number bigger than highest number 
                HighestNumber.Add(firstBiggerNumber);

            }
            catch (System.InvalidOperationException) // Not find any number bigger then highest number
            {
                HighestNumber.Add(smallestNumberInCharList);
                HighestNumber.Add(smallestNumberInCharList);
            }

            for (var i = 0; i < numberInEachPosition.Count() - 1; i++)
            {
                HighestNumber.Add(smallestNumberInCharList);
            }

            return HighestNumber;
        }

        public static int? ListToInt(List<int> result)
        {
            if (result.Count() == 0)
            {
                return null;
            }

            int integer = 0;
            foreach (var number in result)
            {
                integer = integer * 10;
                integer += number;
            }

            return integer;
        }


        public static IEnumerable<int> SplitTheTargetIntoArray(int target)
        {
            var numberInEachPostion = new List<int>();
            var decimalBase = 10;
            while (true)
            {
                var numberInRight = target % decimalBase;
                numberInEachPostion.Add(numberInRight);
                if (target / decimalBase < 1) return numberInEachPostion.Reverse<int>();
                target = target / decimalBase;
            }
        }
    }
}
