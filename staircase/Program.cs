using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staircase
{
    class Program
    {
        static void Main(string[] args)
        {
            Staircase(4);
            Console.ReadLine();
        }

        static void Staircase(int n)
        {
            var decreN = n -1;
            for (var i = 0; i <n ; i++)
            {
                var currentStar = "";
                for (var j = 0; j <decreN ; j++)
                {
                    currentStar += " ";
                }

                decreN -= 1;
                for (var j = 0; j <=i ; j++)
                {
                    currentStar += "#";
                }
                Console.WriteLine(currentStar);
            }
           
        }
    }
}
