using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP.Shared
{
    /// <summary>
    /// Log of message in List
    /// </summary>
    public class Logger
    {
        private static List<string> Messages;

        /// <summary>
        /// Init the logger
        /// </summary>
        static Logger()
        {
            Logger.Init();
        }

        /// <summary>
        /// Reset the logger service
        /// </summary>
        public static void Init()
        {
            Messages = new List<string>();
        }

        /// <summary>
        /// add message to log container
        /// </summary>
        /// <param name="msg"></param>
        public static void Push(string msg)
        {
            Messages.Add(msg);
        }

        /// <summary>
        /// get all logged messages in container
        /// </summary>
        /// <returns></returns>
        public static List<string> Get()
        {
            return new List<string>(Messages);
        }

        /// <summary>
        /// clear the log container and return any messages left
        /// </summary>
        /// <returns></returns>
        public static List<string> Flush()
        {
            var errors = new List<string>(Messages);
            Messages.Clear();

            return errors;
        }
    }
}
