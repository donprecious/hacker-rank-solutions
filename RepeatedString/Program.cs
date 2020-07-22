using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            var count =    repeatedString("abcac", 554045874191);
            //var count = repeatedString("abcac", 10);

            Console.WriteLine(count);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        static string RepeatString(string str, long n)
        {
            // 
            var lengthReached=0;
            var newStr = "";
            
            //infinity loop
            for (int j =0;j<n;j++)
            {
               
                for (var i =0; i<str.Length; i++)
                {
                    if (lengthReached == n) break;

                    newStr += str[i];
                    lengthReached += 1;
                }
                if (lengthReached == n) break;
            }
            return newStr;
        }

        static long repeatedString(string str, long n)
        {
            if (n >= Math.Pow(10, 12)) return n;
           
               
            var repeat = RepeatString(str, n);  
            return repeat.Count(a=> a== 'a');
        }

    }
}
