using System;
using System.Collections.Generic;
using System.Linq;

namespace MajorityElement2
{
    class Program
    {
        static void Main(string[] args)
        {
            int line = Convert.ToInt16(Console.ReadLine());
            var lineNumbers = Console.ReadLine();
            if (!string.IsNullOrEmpty(lineNumbers))
            {
               
              var numbers =   lineNumbers?.Split(" ").ToList().Select(c => Convert.ToInt16(c));
              if (numbers == null) { Console.WriteLine(-1); return;}
              var numsGroup = new List<MajElement>();
              foreach (var number in numbers)
              {

                  var currentNum =numsGroup.FirstOrDefault(a => a.Number == number);
                    if (currentNum != null)
                    {
                        currentNum.Count++;
                    }
                    else
                    {
                        numsGroup.Add(new MajElement()
                        {
                            Number = number,
                            Count = 1
                        });
                    }
                }
              
                var maxCount = numsGroup.Max(a =>  a.Count);
                var maxitem = numsGroup.FirstOrDefault(a => a.Count == maxCount);
                if (maxCount <= 1 || maxitem == null)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(maxitem.Number);
                }
            }
          
        } 


    }

    public class MajElement
    {
        public  int Number { get; set; }
        public  int Count { get; set; }
    }
}
