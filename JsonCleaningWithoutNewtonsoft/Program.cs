using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;

namespace JsonCleaningWithoutNewtonsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");

            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd(); // do something fun...  
                J
                Console.WriteLine(result);
               
            }
            Console.WriteLine(response);
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
