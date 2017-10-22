using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoomingCannon
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string inputSentencse = Console.ReadLine();

            int distance = inputData[0];
            int power = inputData[1];

            Regex battlefield = new Regex(@"(?<=\\<<<)(?<battle>[a-zA-Z]+)");

            var tereni = battlefield.Matches(inputSentencse);
            List<string> destroyedTargets = new List<string>();
            foreach (Match line in tereni)
            {
                var battle = line.Value.ToCharArray().Skip(distance).Take(power).ToArray();
                var result = String.Join("", battle);
                destroyedTargets.Add(result);
            }
            Console.WriteLine(String.Join(@"/\",destroyedTargets));
        }
    }
}
