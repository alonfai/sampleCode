using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Shared
{
    /// <summary>
    /// char comparison helper methods
    /// </summary>
    public class CharEquality
    {
        /// <summary>
        /// match 2 chars with case insensitive
        /// </summary>
        /// <param name="firstChar">first char</param>
        /// <param name="secondChar">second char</param>
        /// <returns></returns>
        public static bool IsCharEqual(char firstChar, char secondChar)
        {
            return (IsCharEqual(firstChar, secondChar, false));
        }

        /// <summary>
        /// match 2 chars with case sensitivity on / off
        /// </summary>
        /// <param name="firstChar">first char</param>
        /// <param name="secondChar">second char</param>
        /// <param name="caseSensitiveCompare">match with case sensitivity on or off</param>
        /// <returns></returns>
        public static bool IsCharEqual(char firstChar, char secondChar, bool caseSensitiveCompare)
        {
            if (caseSensitiveCompare)
            {
                return (firstChar.Equals(secondChar));
            }
            else
            {
                return (char.ToLowerInvariant(firstChar).Equals(char.ToLowerInvariant(secondChar)));
            }
        }
    }
}
