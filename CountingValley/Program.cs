using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValley
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = new char[] {'U', 'D', 'U'};
            //var checkValue = CheckForValley( path);
            //Console.WriteLine(checkValue); 

            var valleys = CountingValleys(8, "DDUUDDUDUUUD");
            Console.WriteLine(valleys);
            Console.ReadLine();
        }
        static int CountingValleys(int n, string s)
        {
            var path = s.ToUpper().ToList();
            //current sealeavel
            int seaLevel = 0;
            //valleys found
            int valleys = 0;
            var pathsBeforeSeaLevel = new List<char>();
            foreach (var i in path)
            {
                //check if step is uphill then increase seaLevel. else decrease
                if (i == 'D')
                {
                    seaLevel -= 1;
                    pathsBeforeSeaLevel.Add(i);
                }
                else if (i == 'U')
                {
                    seaLevel += 1;
                    pathsBeforeSeaLevel.Add(i);
                }
                //check if given path is at sea level 
                if (seaLevel == 0)
                {
                    // loop over pathBeforeSeeLevel to see if the hiker has just hike a valley  
                    //reverse the path for easy 
                    pathsBeforeSeaLevel.Reverse();
                    var isValley = CheckForValley(pathsBeforeSeaLevel.ToArray());
                    if (isValley)
                    {
                        valleys += 1;
                        //clear paths 
                        pathsBeforeSeaLevel.Clear();
                    }
                }
                
            }

            return valleys;
        }   static int CountingValleys2(int n, string s)
        {
            var path = s.ToUpper().ToList();
            //current sealeavel
          
            //current sealeavel
            int seaLevel = 0;
            //valleys found
            int valleys = 0;
            bool inValley = false;
            //    var pathsBeforeSeaLevel = new List<char>();
            foreach (var i in path)
            {
                //check if step is uphill then increase seaLevel. else decrease
                if (i == 'D')
                {
                    seaLevel -= 1;
                    //approaching valley 
                    //inValley = true;
                }
                else if (i == 'U')
                {
                    seaLevel += 1;
                    //leaving valley going upwards
                    // inValley = false;
                    // pathsBeforeSeaLevel.Add(i);
                }

                if (seaLevel < 0 && inValley == false)
                {
                    inValley = true;
                }
                //check if given path is at sea level 
                if (seaLevel == 0 && inValley == true )
                {
                    // hiker is in a valley 

                    valleys++;
                    inValley = false;
                    // loop over pathBeforeSeeLevel to see if the hiker has just hike a valley  
                    //reverse the path for easy 


                    //pathsBeforeSeaLevel.Reverse();
                    //var isValley = CheckForValley(pathsBeforeSeaLevel.ToArray());
                    //if (isValley)
                    //{
                    //    valleys += 1;
                    //    //clear paths 
                    //    pathsBeforeSeaLevel.Clear();
                    //}
                }
                
            }

            return valleys;
        }

        public static bool CheckForValley(char[] arr)
        {
            int nextPath = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[0+nextPath] == 'D')
                {
                    nextPath += 1;
                    if (arr[i + nextPath] == 'U')
                    {
                        return true;
                    }
                }
            }
            return false;

        }


    }
}
