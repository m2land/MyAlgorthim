using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApplication1.Common;
using System.Linq;

namespace Test
{
    [TestClass]
    public class NumberInMixedCharTest
    {
        [TestMethod]
        public void TestSearchMaxInt()
        {
            List<int> example = new List<int>() { 1, 3, 9, 8 };
            var actual = Algorithm.MaxIntInCharCombination(example, 21);
            var expect = 31;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1, 2 };
            actual = Algorithm.MaxIntInCharCombination(example, 29);
            expect = 111;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 2 };
            actual = Algorithm.MaxIntInCharCombination(example, 22);
            expect = 222;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 4, 7, 9 };
            actual = Algorithm.MaxIntInCharCombination(example, 47);
            expect = 49;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 3, 5, 9 };
            actual = Algorithm.MaxIntInCharCombination(example, 39);
            expect = 53;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 3, 5, 9 };
            actual = Algorithm.MaxIntInCharCombinationV2(example, 39).Value;
            expect = 53;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestSplitTheTargetIntoArray()
        {
            var actual = Algorithm.SplitTheTargetIntoArray(1);
            var expect = new List<int> { 1 };


            Assert.IsTrue(expect.Except(actual).Count() == 0);

            actual = Algorithm.SplitTheTargetIntoArray(21);
            expect = new List<int> { 1, 2 };
            Assert.IsTrue(actual.ToList<int>()[0] == 2);
            Assert.IsTrue(expect.Except(actual).Count() == 0);

            actual = Algorithm.SplitTheTargetIntoArray(4568);
            expect = new List<int> { 8, 6, 5, 4 };
            Assert.IsTrue(actual.ToList<int>()[0] == 4);
            Assert.IsTrue(expect.Except(actual).Count() == 0);

            actual = Algorithm.SplitTheTargetIntoArray(0);
            expect = new List<int> { 0 };
            Assert.IsTrue(expect.Except(actual).Count() == 0);
        }

        [TestMethod]
        public void TestSearchMaxIntV2()
        {

            List<int> example = new List<int>() { 2,3,5 };
            var actual = Algorithm.MaxIntInCharCombinationV2(example, 225);
            var expect = 232;
            Assert.AreEqual(expect, actual);

            /*
            List<int> example = new List<int>() { 1, 3, 9, 8 };
            var actual = Algorithm.MaxIntInCharCombinationV2(example, 21);
            var expect = 31;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1 };
            actual = Algorithm.MaxIntInCharCombinationV2(example, 29);
            expect = 111;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1, 3, 6 };
            actual = Algorithm.MaxIntInCharCombinationV2(example, 3);
            expect = 6;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1, 3, 6 };
            actual = Algorithm.MaxIntInCharCombinationV2(example, 0);
            expect = 1;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1, 2, 7 };
            actual = Algorithm.MaxIntInCharCombinationV2(example, 264);
            expect = 271;
            Assert.AreEqual(expect, actual);*/
        }

        [TestMethod]
        public void TestListToInt()
        {
            List<int> example = new List<int>() { 1, 3, 9, 8 };
            var actual = Algorithm.ListToInt(example);
            int? expect = 1398;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { };
            actual = Algorithm.ListToInt(example);
            expect = null;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 0 };
            actual = Algorithm.ListToInt(example);
            expect = 0;
            Assert.AreEqual(expect, actual);

            example = new List<int>() { 1 };
            actual = Algorithm.ListToInt(example);
            expect = 1;
            Assert.AreEqual(expect, actual);

        }

        [TestMethod]
        public void CrossTestTwoMethods()
        {
            var numbers = Enumerable.Range(1, 9).ToList(); // 0-9 inclusive
            var rng = new Random();
            Shuffle(rng, numbers);
            var charList = numbers.Take(3).ToList<int>();

            for (var i = 100; i < 10000; i++)
            {
                Console.WriteLine(string.Format("Char list is {0},{1},{2}, number is {3}", charList[0], charList[1], charList[2], i));
                Assert.AreEqual(Algorithm.MaxIntInCharCombination(charList, i), Algorithm.MaxIntInCharCombinationV2(charList, i));
            }
        }

        public static void Shuffle<T>(Random rng, IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
