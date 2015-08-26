using KMP.Interfaces;
using KMP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    /// <summary>
    /// Start point for KMP Search string program
    /// </summary>
    public class Main
    {
        /// <summary>
        /// get an input strings object, produces matches array of all matches and returns true/false on successful completion without any errors
        /// </summary>
        /// <param name="input"></param>
        /// <param name="matches"></param>
        /// <param name="isCaseSensitive"></param>
        /// <returns></returns>
        public static bool Run(IInput input, out int[] matches, bool isCaseSensitive = false)
        {
            matches = new int[] { };
            if (input == null)
            {
                return false;
            }
            else if (!input.IsValid)
            {
                var errors = input.ErrorList;
                if (errors != null && errors.Count > 0)
                {
                    Logger.Push(Environment.NewLine + "Errors in given input: " + string.Join(", ", errors));
                }
                return false;
            }
            else
            {
                var overlapCalculator = new OverlapCalculator(input.SubText, isCaseSensitive);
                var algo = new Algorithm(input, overlapCalculator, isCaseSensitive);
                matches = algo.FindMatches();
                return true;
            }
        }
    }
}
