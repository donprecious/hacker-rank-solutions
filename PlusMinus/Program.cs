using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusMinus
{
    class Program
    {
        static void Main(string[] args)
        {
            PlusMinus(new int[] {1,1,0,0, 0,-1,-1});
            Console.ReadLine();
        }
        static void PlusMinus(int[] arr) {
            List<int> postiveNumbers =  new List<int>();
            List<int> negativeNumbers = new  List<int>();
             List<int> zeroNumbers = new  List<int>(); 
            foreach (var i in arr)
            {
                if (i < 0)
                {
                    //add to negative 
                    negativeNumbers.Add(i);
                }
                else if (i > 0)
                {
                    postiveNumbers.Add(i);
                }
                else if (i == 0)
                {
                    zeroNumbers.Add(i);
                }
            }

            var totalNumbers = arr.Length;
            if (totalNumbers != 0)
            {
                var negativeDecimal = Math.Round((decimal) negativeNumbers.Count / totalNumbers, 6).ToString("0.000000");
                var positiveDecimal = Decimal.Round((decimal) postiveNumbers.Count / totalNumbers, 6).ToString("0.000000");
                var zeroDecimal =  Math.Round((decimal)zeroNumbers.Count / totalNumbers, 6).ToString("0.000000");
                Console.WriteLine(positiveDecimal);
                Console.WriteLine(negativeDecimal);

                Console.WriteLine(zeroDecimal);
            }
        }

    }
}
