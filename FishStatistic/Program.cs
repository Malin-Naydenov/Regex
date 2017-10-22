using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FishStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFishes = Console.ReadLine();
            string pattern = @"(>*<\(+['\-x]>)";
            Regex aquarium = new Regex(pattern);

            MatchCollection fishes = aquarium.Matches(inputFishes);
            if (fishes.Count == 0)
            {
                Console.WriteLine("No fish found.");
            }
            else
            {


                int count = 1;
                foreach (Match fish in fishes)
                {

                    var fishh = fish.Value.ToString();
                    Console.WriteLine($"Fish {count}: {fishh}");

                    int body = BodyLong(fishh);
                    string bodyType = BodyType(body);

                    int tail = TailLong(fishh);
                    string tailType = TailType(tail);

                    string status = GetStatus(fishh);

                    if (tail == 0)
                    {
                        Console.WriteLine($"  Tail type: {tailType}");
                    }
                    else
                    {
                        Console.WriteLine($"  Tail type: {tailType} ({tail * 2} cm)");

                    }
                    Console.WriteLine($"  Body type: {bodyType} ({body * 2} cm)");
                    Console.WriteLine($"  Status: {status}");


                    count++;
                }
            }
            
        }

        static string GetStatus(string fishh)
        {
            string condition = "";
            if (fishh.Contains("'"))
            {
                condition = "Awake";
            }
            else if (fishh.Contains("-"))
            {
                condition = "Asleep";
            }
            else if (fishh.Contains("x"))
            {
                condition = "Dead";
            }
            return condition;
        }

        private static string BodyType(int body)
        {
            string size = "";
            if (body > 10)
            {
                size = "long";
            }
            else if (body > 5 && body <= 10)
            {
                size = "Medium";
            }
            else if (body <= 5)
            {
                size = "Short";
            }

            return size;
        }

        private static int BodyLong(string fishh)
        {
            string patternBody = @"\(";
            Regex fishBody = new Regex(patternBody);
            var body = fishBody.Matches(fishh).Count;
            return body;
        }

        static string TailType(int tail)
        {
            string size = "";
            if (tail > 5)
            {
                size = "long";
            }
            else if (tail > 1 && tail <= 5)
            {
                size = "Medium";
            }
            else if (tail == 1)
            {
                size = "Short";
            }
            else if (tail < 1)
            {
                size = "None";
            }
            return size;
        }

        static int TailLong(string fishh)
        {
            string pattern = @">";
            Regex tail = new Regex(pattern);
            var tailLong = tail.Matches(fishh).Count;
            return tailLong - 1;
        }
    }
}
