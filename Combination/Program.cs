using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Combination
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new int[]{}.ToString());
            Console.ReadLine();
            // var combinations = Combinations(new string[] {"a"}); 
            //
            // foreach (var combination in combinations)
            // {
            //    Console.WriteLine(combination); 
            // }
        }

        public static string[]  Combinations(string[] elements)
        {
           
            if(elements.Length == 0) return  new string [] {"[]"} ;
            var firstElement = elements[0];
            var rest = elements.Where(a => a != firstElement).ToArray(); 
            var combsWithOutElements = Combinations(rest);
            var combsWithFirst = new List<string>();
            foreach (var item in combsWithOutElements)
            {
                var combWithFirst = new List<string>(){};
                combsWithFirst.Add(item);
                combsWithFirst.Add(firstElement);
                
                combsWithFirst.AddRange(combsWithFirst);
            
            }
            return combsWithFirst.ToArray();
        }
    }
    
}