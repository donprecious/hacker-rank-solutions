using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int pair = SockMerchant(9, new int[]{ 10, 20, 20, 10, 10, 30, 50, 10, 20 });


            Console.WriteLine(pair); 

        }

        static int SockMerchant(int n, int[] ar)
        {
             Array.Sort(ar);

            int noOfPair = 0,  i=0; 
      
           // var currentItem = "";
           while (i < n)
           {
               //check for out of range 
               var range = i + 1;
               if (range < n)
               {
                   if (ar[i] == ar[i + 1])
                   {
                       //set duplicate pair
                       noOfPair += 1;
                       //set i to the next index
                       i = i + 1 + 1;

                   }
                   else
                   {
                       i++;
                   }
               }
               else
               {
                   break;
               }
              
           }
    
           return noOfPair;
        }

        static int DuplicatePair(int n, int[] ar)
        {
            Array.Sort(ar);

            int noOfPair = 0,  i=0; 
      
            // var currentItem = "";
            while (i < n)
            {
                //check for out of range 
                var range = i + 1;
                if (range < n)
                {
                    if (ar[i] == ar[i + 1])
                    {
                        //set duplicate pair
                        noOfPair += 1;
                        //set i to the next index
                        i = i + 1 + 1;

                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    break;
                }
              
            }
    
            return noOfPair;
        }


    }
}
