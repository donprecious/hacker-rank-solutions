using System;
using System.Collections.Generic;

namespace fleetOps_interview
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = "abc"; 
            String str2 = "xya"; 
            int n = str1.Length;
            var permutations1 = new List<string>();
            permute(str1, 0, n - 1, permutations1); 
            var permutations2 = new List<string>();
            permute(str2, 0, n - 1, permutations2);

            Console.WriteLine("writing list permutation 1"); 
            permutations1.ForEach(a=> Console.WriteLine(a)); 
            Console.WriteLine("writing list permutation 2"); 

            permutations2.ForEach(a=> Console.WriteLine(a)); 

            Console.WriteLine("---breaking permutations----");

            var canBreak = CanBreakStrings(permutations1, permutations2);
           Console.WriteLine(canBreak);

        }  

        private static void permute(String str, 
            int l, int r,   List<string> permutations) 
        {
         
            if (l == r)
            {
             
                permutations.Add(str);

            }
               
            else { 
                for (int i = l; i <= r; i++) { 
                    str = swap(str, l, i); 
                    permute(str, l + 1, r, permutations); 
                    str = swap(str, l, i); 
                } 
            } 

        } 
  
   
        public static String swap(String a, 
            int i, int j) 
        { 
            char temp; 
            char[] charArray = a.ToCharArray(); 
            temp = charArray[i]; 
            charArray[i] = charArray[j]; 
            charArray[j] = temp; 
            string s = new string(charArray); 
            return s; 
        }


        public static bool compareTwoString(string str1, string str2)
        {
            List<bool> comparedResults = new List<bool>();
            for (int i = 0; i < str2.Length ; i++)
            {
                var a = str1[i];
                var b = str2[i];
                if (a >= b)
                {
                    comparedResults.Add(true);
                }
                else
                {
                    comparedResults.Add(false);
                }
            }

            if (comparedResults.Contains(false))
            {
                return false;
            }

            return true;
        }

        public static bool CanBreakStrings(List<string> listOfString1 , List<string> listOfStrings2)
        {
            foreach (var string1 in listOfString1)
            {
                //try to  break strings in listOfString2 
                foreach (var string2 in listOfStrings2)
                {
                    var canBreak = compareTwoString(string1, string2);
                    var canBreakReverse = compareTwoString(string2, string1);
                    if (canBreak || canBreakReverse)
                    {
                        return true; 
                    }
                }
            }

            return false;
        }
    }
}
