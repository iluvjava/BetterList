using System;
using System.Collections.Generic;
using System.Threading;

namespace BetterList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BetterList<int> temp = new BetterList<int>();
            temp[9] = 6;
            Console.WriteLine(temp.ToString());
            Thread.Sleep(3000);

        }
    }
}
