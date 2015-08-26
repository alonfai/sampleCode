using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Interfaces
{
    /// <summary>
    /// interface for the KMP Algorithm main execution class
    /// </summary>
    public interface IAlgorithm
    {
        int[] FindMatches();
        string Text { get; set; }
        string SubText { get; set; }
        int[] PrefixTable { get; set; }
        bool IsCaseSensitive { get; set; }
    }
}
