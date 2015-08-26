using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Interfaces
{
    /// <summary>
    /// interface for the prefix table calculator class object
    /// </summary>
    public interface IOverlapCalculator
    {
        int[] Compute();
        string Pattern { get; set; }
        bool IsCaseSensitive { get; set; }
    }
}
