using System;
using SocksLaundryLib;

namespace SocksLaundry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMachineCanWash = 2;
            int[] cleanPile = new int[] { 1, 2, 1, 1 };
            int[] dirtyPile = new int[] { 1, 4, 3, 2, 4 };
            int pairs = new ClassLib().GetMaximumPairOfSocks(numberMachineCanWash, cleanPile, dirtyPile);
            Console.WriteLine(pairs);
            Console.ReadKey();
        }
    }
}
