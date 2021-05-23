using System;
using System.Collections.Generic;
using System.Linq;


namespace JsonCleaning
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData = "";
            string line;
            List<Person> persons = new List<Person>();
            while ( !string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var lineArr = line.Split(',');
                persons.Add(new Person()
                {
                    Height = Convert.ToInt32(lineArr[0]),
                    Weight = Convert.ToInt32(lineArr[1])
                });
            }

          
            persons = persons.OrderBy(a => a.Height).ThenBy(a => a.Weight).ToList();
            var previousPerson = new  Person();
            var nextPerson = new Person();
            for (
                
                int i = 0; i < persons.Count(); i++)
            {
                if (i == 0)
                {
                    previousPerson = null;
                }

                var currentPerson = persons[i];
                    if (previousPerson == null && i >0)
                    {
                        previousPerson = persons[i - 1];
                    }
                    nextPerson = new Person();
                    if (i < persons.Count() -1)
                    {
                        nextPerson = persons[i + 1];
                    }
                    else
                    {
                        nextPerson = null;
                    }

                    if (nextPerson == null)
                    {
                        Console.WriteLine(currentPerson.Height.ToString() + "," + currentPerson.Weight.ToString()); 
                        
                    }
                    else
                    {
                        if (previousPerson == null)
                        {
                            var currentPassedNext = 
                                (currentPerson.Height < nextPerson.Height &&
                                                 currentPerson.Weight < nextPerson.Weight);
                            if (currentPassedNext)
                            {
                                Console.WriteLine(currentPerson.Height.ToString() + "," + currentPerson.Weight.ToString());
                            }
                            else
                            {
                                
                                previousPerson = null;
                                i = 0; 
                            }
                        }
                        else
                        {
                            var currentPassedPrevious = (currentPerson.Height > previousPerson.Height &&
                                                         currentPerson.Weight > previousPerson.Weight);
                            var currentPassedNext = (currentPerson.Height < nextPerson.Height &&
                                                     currentPerson.Weight < nextPerson.Weight);
                            if (currentPassedNext && currentPassedPrevious)
                            {
                                Console.WriteLine(currentPerson.Height.ToString() + "," + currentPerson.Weight.ToString());
                                previousPerson = null;
                            }
                            else
                            {
                                previousPerson = previousPerson;
                            }
                    }
                        
                    }
                   

                
                
            }
            
            // Do not edit: Output solution to console
            Console.ReadLine();
        }

        public class Person
        {
            public int Height { get; set; } 
            public  int Weight { get; set; }
        }

        static void LongString(string[] args)
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t)) Console.WriteLine("false");

            var sString = s.Split('=')[1];
            var tArrStr = t.Split('=')[1];
            var tArr = tArrStr.Split(" ");

            foreach (var tItem in tArr)
            {
                if (sString.ToLower().Contains(tItem.ToLower()))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
            Console.ReadLine();
        }



        static void SomeOthers(string[] args)
        {
            //WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");

            //WebResponse response = request.GetResponse();
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    string result = reader.ReadToEnd(); // do something fun...  
            //    Console.WriteLine(result);
            //    JsonConvert.DeserializeObject(result);
            //}
            //Console.WriteLine(response);
        }
    }
}
