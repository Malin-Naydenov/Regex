using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HappinessIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int happiness = HowMatchHappy(input);
            int sad = HowMatchSad(input);

            double result = happiness / (double)sad;

            if(result >= 2)
            {
                Console.WriteLine($"Happiness index: {result:f2} :D");
            }
            else if (result > 1 && result<2)
            {
                Console.WriteLine($"Happiness index: {result:f2} :)");
            }
            else if(result == 1)
            {
                Console.WriteLine($"Happiness index: {result:f2} :|");
            }
            else if (result < 1)
            {
                Console.WriteLine($"Happiness index: {result:f2} :(");
            }
            Console.WriteLine($"[Happy count: {happiness}, Sad count: {sad}]");

        }

        private static int HowMatchSad(string input)
        {
            Regex regex = new Regex(@":\(|D:|;\(|:\[|;\[|:{|;{|\):|:c|]:|];");
            var sadCount = regex.Matches(input).Count;
            return sadCount;
        }

        private static int HowMatchHappy(string input)
        {
            Regex happy = new Regex(@":\)|:D|;\)|:\*|:]|;]|:}|;}|\(:|\*:|c:|\[:");
            var happinessCount = happy.Matches(input).Count;
            return happinessCount;
        }
    }
}
