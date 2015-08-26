using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Shared
{
    /// <summary>
    /// Different constant error messages working with the KMP solution
    /// </summary>
    public class Errors
    {
        public const string EmptyText = "Text was empty";
        public const string EmptySubText = "SubText was empty";
        public const string SubTextLongerThanText = "SubText is longer than Text";
        public const string InputWasNull = "Input param was null";
        public const string InputWasInvalid = "Input param was invalid";
        public const string OvelapCalculatorWasNull = "Overlap calculator object was null";
    }
}
