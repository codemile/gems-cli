using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;

namespace GemsCLI
{
    public class Help
    {
        /// <summary>
        /// The help messages.
        /// </summary>
        private readonly IDictionary<string, string> _messages;

        /// <summary>
        /// Splits a string by it's length.
        /// </summary>
        private static IEnumerable<string> SplitByLength(string pStr, int pMaxLength)
        {
            for (int index = 0; index < pStr.Length; index += pMaxLength)
            {
                yield return pStr.Substring(index, Math.Min(pMaxLength, pStr.Length - index));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDescription">The argument descriptions</param>
        public Help(DescriptionList pDescription)
        {
            _messages = new Dictionary<string, string>();
        }

        /// <summary>
        /// Displays command line usage.
        /// </summary>
        public void Show()
        {
            const int chunkSize = 80;

            Console.WriteLine(@"Usage: {0} [OPTIONS]", "test");
            Console.WriteLine();

            int width = (from name in _messages.Keys select name.Length).Max() + 1;

            foreach (KeyValuePair<string, string> pair in _messages)
            {
                string str = pair.Key;
                string[] lines = SplitByLength(str, chunkSize).ToArray();
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(i == 0 ? @"--{0} {1}" : "{2} {1}", pair.Value.PadRight(width), lines[i],
                        new String(' ', width));
                }
            }
        }
    }
}