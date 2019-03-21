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

        [Test]
        public void testBetterList()
        { 
            BetterList<int> temp = new BetterList<int>();
            temp[9] = 6;
            temp[-2] = 7;
            Console.WriteLine(temp.ToString());
            Console.WriteLine("Slice with -3:-1"+ temp[-3, -1].ToString());


        }
    }
}