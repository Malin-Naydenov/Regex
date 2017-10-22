using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageSoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Decrypt!")
            {
            int number = int.Parse(Console.ReadLine());
                string result = "";

                if (IsValidInput(input))
                {
                    string word = GetWord(input);
                    if (word.Length == number)
                    {
                        var digits = GetDigits(input);

                        foreach (var digit in digits)
                        {
                            if (digit <= word.Length - 1)
                            {
                                var letter = word.Substring(digit, 1);

                                result += letter;
                            }
                        }
                        Console.WriteLine($"{word} = {result}");
                    }
                }
                    input = Console.ReadLine();
                   // number = int.Parse(Console.ReadLine());
            }
        }

        private static List<int> GetDigits(string input)
        {
            List<int> listOfDigits = new List<int>();
            Regex regex = new Regex(@"\d");
            var digits = regex.Matches(input);
            foreach (Match d in digits)
            {
                int dig = int.Parse(d.Value);
                listOfDigits.Add(dig);
            }
            return listOfDigits;
        }

        private static string GetWord(string input)
        {
            string result = "";
            Regex regex = new Regex(@"(?<=[0-9])([A-Za-z]+)");
            var words = regex.Matches(input);
            foreach (var word in words)
            {
                result += word.ToString();

            }


            return result;
        }

        private static bool IsValidInput(string input)
        {
            Regex regex = new Regex(@"(?<=[0-9])([A-Za-z]+)");
            var valid = regex.IsMatch(input);
            return valid;

        }
    }
}
