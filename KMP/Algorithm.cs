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
    /// KMP Algorithm main execution class
    /// </summary>
    public class Algorithm : IAlgorithm
    {
        public string Text { get; set; }
        public string SubText { get; set; }
        public int[] PrefixTable { get; set; }
        public bool IsCaseSensitive { get; set; }

        /// <summary>
        /// Constructor (throws ArgumentException on invalid input)
        /// </summary>
        /// <param name="input">input object</param>
        /// <param name="caseSensitive">flag whether find matches with case sensitive or not (default to case insensitive)</param>
        public Algorithm(IInput input, IOverlapCalculator Table, bool caseSensitive = false)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(Errors.InputWasNull);
                }

                if (!input.IsValid)
                {
                    throw new ArgumentException(Errors.InputWasInvalid);
                }

                if (Table == null)
                {
                    throw new ArgumentNullException(Errors.OvelapCalculatorWasNull);
                }

                this.Text = input.Text;
                this.SubText = input.SubText;
                this.PrefixTable = Table.Compute();
                this.IsCaseSensitive = caseSensitive;
            }
            catch (Exception e)
            {
                Logger.Push("Error received while initializing the KMPAlgorithm class object : " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Return an array of matches with index position where pattern was found in main Text
        /// </summary>
        /// <returns></returns>
        public int[] FindMatches()
        {
            var matches = new List<int>();
            var indexText = 0;
            var textLength = this.Text.Length - 1;
            var indexPattern = 0;
            var patternLength = this.SubText.Length - 1;
            var iterator = 0;

            while (textLength - iterator >= patternLength)
            {
                var foundMatch = MatchStrings(ref indexText, ref indexPattern, patternLength);
                if (foundMatch)
                {
                    matches.Add(iterator + 1);
                }

                ResetIndexText(ref indexText, indexPattern, ref iterator);
                ResetIndexPattern(ref indexPattern);
            }

            return matches.ToArray();
        }

        /// <summary>
        /// restart the location of both Text string and output 
        /// </summary>
        /// <param name="indexText"></param>
        /// <param name="indexPattern"></param>
        /// <param name="iterator"></param>
        private void ResetIndexText(ref int indexText, int indexPattern, ref int iterator)
        {
            if (indexPattern > 0 && this.PrefixTable[indexPattern - 1] > 0)
            {
                iterator = indexText - this.PrefixTable[indexPattern - 1];
            }
            else
            {
                if (indexText == iterator)
                {
                    indexText += 1;
                }

                iterator = indexText;
            }
        }

        /// <summary>
        /// restart the location in SubText string at end of iteration from the Prefix table
        /// </summary>
        /// <param name="index"></param>
        private void ResetIndexPattern(ref int index)
        {
            if (index > 0)
            {
                index = this.PrefixTable[index - 1];
            }
        }

        /// <summary>
        /// calculate all matches of chars in the Text and SubText strings
        /// </summary>
        /// <param name="indexText">location in text for current algo iteration</param>
        /// <param name="indexPattern">location in pattern for current algo iteration</param>
        /// <param name="patternLength">string length of pattern string</param>
        /// <returns></returns>
        private bool MatchStrings(ref int indexText, ref int indexPattern, int patternLength)
        {
            while (
                indexPattern <= patternLength && 
                CharEquality.IsCharEqual(this.Text[indexText], this.SubText[indexPattern], IsCaseSensitive))
            {
                indexPattern += 1;
                indexText += 1;
            }

            return indexPattern > patternLength;
        }
    }
}
