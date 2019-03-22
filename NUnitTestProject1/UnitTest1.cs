using NUnit.Framework;
using BetterList;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        /// <summary>
        /// A static func for func. 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static bool isodd(int a)
        {
            return a % 2==1;
        }

        static bool isValidDouble(double arg)
        {
            bool res = true;
            res &= Double.IsFinite(arg);
            res &= !Double.IsNaN(arg);
            return res; 
        }

        [Test]
        public void testBetterList()
        {
            scope1:
            {
                BetterList<int> temp = new BetterList<int>();
                temp[9] = 6;
                temp[-2] = 7;
                Console.WriteLine(temp.ToString());
                Console.WriteLine("Slice with 1:-2" + temp[1, -2].ToString());
                Console.WriteLine("Clise with -3,0,3" + temp[-3, 0, 3].ToString());
                Func<int, bool> testFunc = isodd;
                Console.WriteLine("Filter out the odd index element..");
                Console.WriteLine(temp[testFunc].ToString());
            }


            {
                Func<double, bool> func = isValidDouble;
                Func<double, bool> func2 = (double a) => { return a != 0; };

                BetterList<double> temp = new BetterList<double>();
                temp[9] = Double.NaN;
                temp[5] = Double.NegativeInfinity;
                temp[2] = 3.14;
                temp[1] = 0; 
                Console.WriteLine(temp.ToString());
                Console.WriteLine("Filter out all invalid doubles: ");
                Console.WriteLine(temp[func].ToString());
                Console.WriteLine("Filler out all non negative element in the list: ");
                Console.WriteLine(temp[func2].ToString());


            }


        }
    }
}