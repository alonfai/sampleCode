using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Interfaces
{
    /// <summary>
    /// interface for the KMP algorithm input object
    /// </summary>
    public interface IInput
    {
        string Text { get; set; }
        string SubText { get; set; }
        List<string> ErrorList { get; set; }
        bool IsValid { get; }
    }
}
