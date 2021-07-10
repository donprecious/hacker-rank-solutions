using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace JsonCleaningWithoutNewtonsoft
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");

            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd(); // do something fun...  

                var s = FilterJsonResponse(result);
                Console.WriteLine(s);
                Console.WriteLine(result);
               
            }
            Console.WriteLine(response);
        }

        private static string FilterJsonResponse(string jsonString)
        {
            string originalEmptyValues = "(\"\"|\"[-]\"|\"N\\/A\")";
            string emptyPlaceholder = "#empty#";
            string emptyKeyValues = "(\"[a-zA-Z]+\":#empty#,|,\"[a-zA-Z]+\":#empty#)";
            string emptyArrayValues = "(#empty#,|,#empty#)";
            string result = Regex.Replace(jsonString, originalEmptyValues, emptyPlaceholder);
            result = Regex.Replace(result, emptyKeyValues, "");
            result = Regex.Replace(result, emptyArrayValues, "");

            return result;

        }
    }

    public static class JSONSerializer<TType> where TType : class
    {
        /// <summary>
        /// Serializes an object to JSON
        /// </summary>
        public static string Serialize(TType instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(TType));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// DeSerializes an object from JSON
        /// </summary>
        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }
}
