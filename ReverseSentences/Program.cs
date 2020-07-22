using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSentence = Convert.ToInt16(Console.ReadLine());
            List<string> sentenceList = new List<string>();
            for (int i = 0; i < numberOfSentence; i++)
            {
                var line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                     var sentence  = line.Trim().Split(" ").ToList();
                     sentence.Reverse();
                    var reversedLine = string.Join(" ", sentence) ; 
                    sentenceList.Add(reversedLine);
                }
               
            }

            foreach (var sentence in sentenceList)
            {
                Console.WriteLine(sentence.Trim());
            }
        }
    }
}
