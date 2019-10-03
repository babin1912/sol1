using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace babinskyUloha1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            Console.WriteLine(input);
            var separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };
            var words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            //int numOfCharsWithoutSpaces = Regex.Replace(input, " ", String.Empty).Length;
            //foreach (string word in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) Console.WriteLine(word);

            //Console.WriteLine(Regex.Replace(input, "[^A-Za-z0-9 ]", String.Empty));
            
            Console.WriteLine("Number of characters (with spaces): " + input.Length);
            Console.WriteLine("Number of characters (no spaces): " + Regex.Replace(input, " ", string.Empty).Length);
            
            Console.WriteLine("Number of vowels: " + GetNumberOfVowels(input));
            Console.WriteLine("Number of consonants: " + (Regex.Replace(input, "[^A-Za-z0-9]", string.Empty).Length - GetNumberOfVowels(input)));
            
            Console.WriteLine("Number of words: " + words.Length);
            Console.WriteLine("Number of unique words: " + WordsToDictionary(words));
            Console.WriteLine("Number of sentences: " );
            //Word word = new Word(input);
            //Console.WriteLine("Hello World!");
        }

        private static int GetNumberOfVowels(in string input)
        {
            //Toto je jednoducha prva veta. 10,14  Toto je druha veta. 7,8 Tretia veta. 5,5 Poslednou bude veta, ktora je stvrta. 12,18
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y'};
            return input.Count(x => vowels.Contains(x)); ;
        }
        

        private static Dictionary<string, int> WordsToDictionary(in string[] input)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in input)
            {
                try
                {
                    
                    dict.Add(word, 0);
                }
                catch (ArgumentException)
                {
                    dict[word]++;
                }
            }

            foreach (var word in dict)
            {
                Console.WriteLine (" "+word);
            }
            return dict;
        }
    }
}
