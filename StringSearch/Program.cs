using KMP;
using KMP.Interfaces;
using KMP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearchConsoleApp
{
    public class Program
    {
        public static IInput ReadInput()
        {
            //READ TEXT
            //---------
            Console.WriteLine("Enter text");
            var text = Console.ReadLine();

            //READ PATTERN
            //------------
            Console.WriteLine("Enter pattern");
            var subText = Console.ReadLine();

            return new Input(text, subText);
        }

        public static void Main(string[] args)
        {
            var isValid = false;
            int[] matches;
            do
            {
                var input = ReadInput();
                isValid = KMP.Main.Run(input, out matches, false);
                if (!isValid)
                {
                    var errors = Logger.Flush();
                    foreach (var err in errors)
                    {
                        Console.WriteLine(err);
                    }
                }
            } while (!isValid);

            if (matches != null && matches.Length > 0)
            {
                Console.WriteLine("Matches found in the following indexes : " + string.Join(",", matches));
            }
            else
            {
                Console.WriteLine("No matches were found");
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.Read();
        }
    }
}
