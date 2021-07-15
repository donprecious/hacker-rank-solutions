using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace JsonCleaningWithNewtonSof
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");

            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd(); // do something fun...  

                dynamic json = JObject.Parse(result);
                RemoveJson(json["name"]);
                RemoveJson(json["age"]);
                RemoveJson(json["DOB"]);
                RemoveJson(json["hobbies"]);
                RemoveJson(json["education"]);
                Console.WriteLine(json);
                
                Console.WriteLine(result);

            }

            Console.WriteLine(response);
        }

        static void RemoveJson(dynamic node)
        {
            bool removed = true;
            while (removed)
            {
                try
                {
                    foreach (var item in node)
                    {
                        if (item.Value.ToString() == "" || item.Value.ToString() == "N/A")
                        {
                            item.Remove();
                            removed = true;
                            break;
                        }
                        else
                            removed = false;
                    }
                }
                catch (Exception)
                {
                    removed = false;
                }
            }
        }

      

    }
}