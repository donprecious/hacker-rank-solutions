using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
         MiniMaxSum(new long[] {256741038, 623958417, 467905213, 714532089, 938071625});
         Console.ReadLine();
        }
        static void MiniMaxSum(Int64[] arr)
        {
            Array.ConvertAll(arr, a => Convert.ToInt64(a));
           var parr = arr.Where(a => a > 0).ToArray();
            Array.ConvertAll(parr, a => Convert.ToInt64(a));

            var minValue = new List<Int64>(); ;
            minValue.Add(parr.Min());
            var maxValue = new List<Int64>();
                maxValue.Add(parr.Max());
              
           
            var maxArrValues =  parr.Except(minValue);
            var minArrValues = parr.Except(maxValue);

            Int64 minSum = minArrValues.Sum();
            Int64 maxSum = maxArrValues.Sum();
            Console.Write(minSum +" "+maxSum);

        }
    }
}
