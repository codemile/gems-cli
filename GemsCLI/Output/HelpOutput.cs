using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;

namespace GemsCLI.Output
{
    /// <summary>
    /// Handles the displaying of help for parameters.
    /// </summary>
    public class HelpOutput
    {
        /// <summary>
        /// The parser options.
        /// </summary>
        private readonly ParserOptions _options;

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
        /// <param name="pOptions">The parser options</param>
        public HelpOutput(ParserOptions pOptions)
        {
            _options = pOptions;
        }

        /// <summary>
        /// Displays command line usage.
        /// </summary>
        public void Show(ICollection<Description> pDescriptions)
        {
            const int chunkSize = 80;

            Console.WriteLine(@"Usage: {0} [OPTIONS]", OutputFormatter.AppName());
            Console.WriteLine();

            int maxNameWidth = (from desc in pDescriptions select desc.Name.Length).Max() + 1;
            string padding = new String(' ', maxNameWidth);

            foreach (Description desc in pDescriptions)
            {
                string[] lines = SplitByLength(desc.Help, chunkSize).ToArray();
                for (int i = 0; i < lines.Length; i++)
                {
                    string format = i == 0 ? @"{0}{1} {2}" : "{3} {2}";

                    Console.WriteLine(format,
                        _options.Prefix,
                        desc.Name.PadRight(maxNameWidth),
                        lines[i],
                        padding);
                }
            }
        }
    }
}