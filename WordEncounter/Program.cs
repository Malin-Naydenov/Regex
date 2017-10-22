using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordEncounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbols = Console.ReadLine();
            string inputText = Console.ReadLine();
            List<string> selectWords = new List<string>();
            while (inputText != "end")
            {
                var sentence = IsValidSentence(inputText);
                if(sentence)
                {
                    var letter = GetLetter(symbols);
                    var digit = GetDigit(symbols);
                    var words = inputText.Split(new[] { ' ' });

                    foreach (var word in words)
                    {
                        var clearWord = ClearWord(word);
                        
                        Regex letterInWord = new Regex(letter);
                        var result = letterInWord.Matches(clearWord);

                        if(result.Count == digit)
                        {
                            selectWords.Add(clearWord);
                        }
                    }

                }
                inputText = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ",selectWords));
        }

         static string ClearWord(string word)
        {
            string bla = "";
            Regex data = new Regex(@"[a-zA-Z]+");
            var result = data.Matches(word);
            foreach (Match item in result)
            {

             bla+= item.Value;
            }
            return bla;
        }

        private static int GetDigit(string symbols)
        {
            int totalDigit = 0;
            Regex digit = new Regex(@"\d+");
            var result = digit.Match(symbols).ToString();
            var total = int.TryParse(result,out totalDigit);
            return totalDigit;
        }

        static string GetLetter(string symbols)
        {
            Regex data = new Regex(@"[a-zA-Z]");
            var letter = data.Match(symbols).ToString();
            return letter;
        }

        static bool IsValidSentence(string inputText)
        {
            bool sentence = false;
            bool first = IsFirst(inputText);
            Regex sentenceLast = new Regex(@"[.?!]$");
            bool last = sentenceLast.IsMatch(inputText);
            
            if(first==true && last==true)
            {
                sentence = true;
            }
            return sentence;
        }

        private static bool IsFirst(string inputText)
        {
            Regex sentenceFirst = new Regex(@"^[A-Z]");
            bool first = sentenceFirst.IsMatch(inputText);
            return first;
            
        }
    }
}
