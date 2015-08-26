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
    /// KMP Algorithm class input object
    /// </summary>
    public class Input : IInput
    {
        /// <summary>
        /// Main text to search in
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// SubText text to search inside main text
        /// </summary>
        public string SubText { get; set; }

        /// <summary>
        /// list of errors in the input array
        /// </summary>
        public List<string> ErrorList { get; set; }

        public Input()
        {
            this.Text = this.SubText = string.Empty;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="subText"></param>
        /// <param name="text"></param>
        public Input(string text, string subText)
        {
            this.Text = text;
            this.SubText = subText;
        }

        /// <summary>
        /// Does the input strings form a valid text and subText values
        /// </summary>
        public bool IsValid
        {
            get
            {
                Validate();
                return ErrorList.Count == 0;
            }
        }

        /// <summary>
        /// Validate input object is ok before execute the KMP algo on it
        /// </summary>
        /// <returns></returns>
        private void Validate()
        {
            ErrorList = new List<string>();
            if (string.IsNullOrEmpty(Text))
            {
                ErrorList.Add(Errors.EmptyText);
            }
            if (string.IsNullOrEmpty(SubText))
            {
                ErrorList.Add(Errors.EmptySubText);
            }
            if (SubText!=null && Text!=null && SubText.Length > Text.Length)
            {
                ErrorList.Add(Errors.SubTextLongerThanText);
            }
        }
    }
}
