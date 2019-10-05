using System;
using System.Collections;
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
            var input = args[0];
            

            //Console.WriteLine(peter[0]);
            Console.WriteLine(input);
            var separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };
            var words = input.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            //int numOfCharsWithoutSpaces = Regex.Replace(input, " ", String.Empty).Length;
            //foreach (string word in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) Console.WriteLine(word);

            //Console.WriteLine(Regex.Replace(input, "[^A-Za-z0-9 ]", String.Empty));
            
            Console.WriteLine("Number of characters (with spaces): " + input.Length);
            Console.WriteLine("Number of characters (no spaces): " + Regex.Replace(input, " ", string.Empty).Length);
            
            Console.WriteLine("Number of vowels: " + GetNumberOfVowels(input));
            Console.WriteLine("Number of consonants: " + ( GetNumberOfConstants(Regex.Replace(input, "[^A-Za-z0-9]", string.Empty))));
            
            Console.WriteLine("Number of words: " + words.Length);
            Console.WriteLine("Number of unique words: " + StuffToDictionary(words).Count);
            var numberOfSentences = NumberOfSentences(input);
            Console.WriteLine("Number of sentences: " + numberOfSentences);
            Console.WriteLine("Average sentence length (words): " +((double)words.Length/numberOfSentences) );

            Console.WriteLine();
            Console.WriteLine("Character frequencies:\n" + FrcajVystupSorted(StuffToDictionary(Regex.Replace(input.ToLower(), "[^A-Za-z0-9]",string.Empty))));
            
            Console.WriteLine();
            Console.WriteLine("Word frequencies:\n" + FrcajVystupSorted(StuffToDictionary(words)));
            //Word word = new Word(input);
            //Console.WriteLine("Hello World!");
        }

        private static int GetNumberOfConstants(string input)
        {
            bool reducer = false;
            int counter = 0;
            char[] vowels = { 'i', 'e', 'a', 'o', 'u', 'y' };
            foreach (var ch in input)
            {
                if (!vowels.Contains(ch))
                {

                    counter++;
                    if (!ch.Equals('c'))
                    {
                        if (ch.Equals('h')&&reducer)
                        {
                            counter--;
                        }
                        reducer = false;
                    }
                    else
                    {
                        reducer = true;
                    }
                }
            }
            //input.Count(x => vowels.Contains(x)); ;

            return counter;
        }

        private static int NumberOfSentences(string input)
        {
            var sum = 0;
            var chars = new List<string> {".", "!", "?"};
                int calc = 0;
            foreach (var ch in input)
            {
                if (chars.Contains(ch.ToString()) && calc == 0)
                {
                    calc=1;
                    //Console.WriteLine("");
                } else if (ch ==' ' && calc == 1  /*&& ch == 1*//*ch==2 && ch.ToString().Contains()*/)
                {
                    //ch.Equals((ch.ToString().Contains())&& calc == 1 
                    calc = 2;

                }
                else if(char.IsUpper(ch) && calc==2)
                {
                    sum++;
                    calc = 0;
                }
                else
                {
                    calc = 0;
                }
                
            }

            if (input.Length !=0)
            {
                sum++;
            }
            
            return sum;
        }

        private static int GetNumberOfVowels(in string input)
        {
            //Toto je jednoducha prva veta. 10,14  Toto je druha veta. 7,8 Tretia veta. 5,5 Poslednou bude veta, ktora je stvrta. 12,18
            char[] vowels = { 'i', 'e','a', 'o', 'u', 'y'};
            char[] vowelsDual = { 'e', 'a',  'u' };
            int counter =0;
            bool reducer = false;
            foreach (var ch in input)
            {
                if (vowels.Contains(ch))
                {
                    if (ch=='i')
                    {
                        reducer = true;
                        counter++;

                    }
                    else if (!vowelsDual.Contains(ch)||!reducer)
                    {
                        counter++;
                        reducer = false;
                    }
                    else
                    {
                        reducer = false;
                        //Console.WriteLine("i"+ch);
                    }
                    
                }
            }
            
            return counter; 
        }
        

        private static Dictionary<object, int> StuffToDictionary<T>(IEnumerable<T> input)
        {
            var dict = new Dictionary<object, int>();

            foreach (var key in input)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key]++;
                }
                else
                {
                    dict[key] = 1;
                }
            }


            return dict;
        }

        public static string FrcajVystupSorted(Dictionary<object,int> input)
        {
            var things = from character in input
                orderby character.Value descending
                select character;
            string output = "";
            foreach (var word in things)
            {
                output = string.Concat(output,word.Key,": ",word.Value,"x\n");
            }

            return output;
        }

         
    }
}
