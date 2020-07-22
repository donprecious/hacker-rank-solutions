using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            var roundups = GradingStudents(new List<int>()
            {
                4,
                73,
                67,
                38,
                33
            });
            Console.WriteLine(String.Join("\n", roundups));
            Console.ReadLine();
        }  

        public static List<int> GradingStudents(List<int> grades)
        {
            List<int> roundedGrades = new List<int>(); 
            //iterates over grades 
            foreach (var i in grades)
            {
                if (i < 38)
                {
                    roundedGrades.Add(i);
                    continue;
                }
                else
                {
                    //calculate the multiple of 5 for this number using (i/5 + 1)*5
                    int m5 = ( (i / 5) + 1) * 5; 
                    int diff = m5-i;
                    if (diff < 3)
                    {
                        roundedGrades.Add(m5);
                    }
                    else
                    {
                        roundedGrades.Add(i);
                    }
                }
            }
            return roundedGrades; 
        }
    }
}
