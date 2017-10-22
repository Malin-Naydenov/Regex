using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cards
{
    class Cards
    {
        static void Main(string[] args)
        {
            string inputCards = Console.ReadLine();

            string pattern = @"(^|(?<=[HSDC10]))(10[HSDC]|10|[0-9JQKA][HSDC])";

            Regex selectCard = new Regex(pattern);
            var validCards = selectCard.Matches(inputCards);
            StringBuilder builder = new StringBuilder();
            foreach (Match card in validCards)
            {
                builder.Append(card.Value + ", ");
            }
            builder.Remove(builder.Length - 2, 2);
            Console.WriteLine(builder.ToString());
        }
    }
}
