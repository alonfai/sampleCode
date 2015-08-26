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
    /// The KMP Algorithm overlapping calculator object
    /// </summary>
    public class OverlapCalculator : IOverlapCalculator
    {
        public string Pattern { get; set; }
        public bool IsCaseSensitive { get; set; }

        /// Constructor (throws ArgumentException on invalid input)
        /// </summary>
        /// <param name="subText"></param>
        /// <param name="bCaseSensitive">flag whether find matches with case sensitive or not (default to case insensitive)</param>
        public OverlapCalculator(string subText, bool bCaseSensitive = false)
        {
            try
            {
                if (string.IsNullOrEmpty(subText)) //validate input
                {
                    throw new ArgumentNullException(Errors.EmptySubText);
                }
                this.Pattern = subText;
                this.IsCaseSensitive = bCaseSensitive;
            }
            catch (Exception e)
            {
                Logger.Push("Error received while initalizing the ovelapCalculator class object : " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// compute the ovelaps array on finding matching prefixes with suffixes
        /// </summary>
        /// <returns></returns>
        public int[] Compute()
        {
            var patternLen = Pattern.Length;
            var res = new int[patternLen];

            res[0] = 0;
            var iterator = 0;
            for (var index = 1; index < patternLen; index++)
            {
                var currentChar = Pattern[index];
                while (iterator > 0 &&  !CharEquality.IsCharEqual(Pattern[iterator], currentChar, IsCaseSensitive))
                {
                    iterator = res[iterator];
                }

                if (CharEquality.IsCharEqual(Pattern[iterator], currentChar, IsCaseSensitive))
                {
                    iterator += 1;
                }
                res[index] = iterator;
            }

            return res;
        }
    }
}
