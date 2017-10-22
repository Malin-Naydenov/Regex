
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Grocery_Shop
{
    class GroceryShop
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, double>();
            var regex = @"^[A-Z][a-z]+:\d+\.\d{2}$";
            while (input != "bill")
            {
                if (Regex.IsMatch(input, regex))
                {
                    var splitInput = input.Split(':');
                    var groceryName = splitInput[0];
                    var price = double.Parse(splitInput[1]);

                    if (!result.ContainsKey(groceryName))
                    {
                        result.Add(groceryName, price);
                    }
                    else
                    {
                        result[groceryName] = price;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in result.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{kvp.Key} costs {kvp.Value:F2}");
            }
        }
    }
}