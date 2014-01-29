using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;
using GemsCLI.Enums;

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
        private readonly CliOptions _options;

        /// <summary>
        /// The output handler.
        /// </summary>
        private readonly iOutputHandler _output;

        /// <summary>
        /// True to show named parameters on usage line.
        /// </summary>
        private readonly bool _usageNamed;

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
        /// Formats how the passed arguments are shown on the usages message.
        /// </summary>
        /// <param name="pDescriptions">The descriptions</param>
        /// <returns>The formatted passed arguments</returns>
        private static string getPassedUsage(IEnumerable<Description> pDescriptions)
        {
            IEnumerable<string> passed = from desc in pDescriptions
                                         where desc.Role == eROLE.PASSED
                                         let str =
                                             desc.Scope == eSCOPE.REQUIRED
                                                 ? desc.Name
                                                 : string.Format("[{0}]", desc.Name)
                                         select str;

            string passedUsage = string.Join(" ", passed);

            return passedUsage;
        }

        /// <summary>
        /// Displays a parameter description.
        /// </summary>
        /// <param name="pMaxNameWidth">Width of the name column.</param>
        /// <param name="pDesc">The parameter description to display.</param>
        private void Display(int pMaxNameWidth, Description pDesc)
        {
            int max = pMaxNameWidth + _options.Prefix.Length;

            string padding = new String(' ', max);
            const int chunkSize = 80;

            string[] lines = SplitByLength(pDesc.Help, chunkSize).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                string format = i == 0 ? @"  {0} {1}" : "  {2} {1}";

                string name = (pDesc.Role == eROLE.NAMED ? _options.Prefix : "") +
                              pDesc.Name +
                              (pDesc.Scope == eSCOPE.OPTIONAL ? "*" : "");

                _output.WriteLine(string.Format(format,
                    name.PadRight(max),
                    lines[i],
                    padding));
            }
        }

        /// <summary>
        /// Walks all the descriptions and returns the width of the longest name.
        /// </summary>
        /// <param name="pDescriptions">The descriptions</param>
        /// <returns>Length of longest name</returns>
        private int getMaxNameWidth(IEnumerable<Description> pDescriptions)
        {
            int maxNameWidth = (from desc in pDescriptions select desc.Name.Length + _options.Prefix.Length).Max();
            return maxNameWidth;
        }

        /// <summary>
        /// Formats how the options message in the usage line is displayed.
        /// </summary>
        /// <param name="pDescriptions">The descriptions.</param>
        /// <returns>The options message.</returns>
        private string getNamedUsage(IEnumerable<Description> pDescriptions)
        {
            string options = string.Format("[{0}options]", _options.Prefix);
            if (!_usageNamed)
            {
                return options;
            }

            IEnumerable<string> names = from desc in pDescriptions
                                        where desc.Role == eROLE.NAMED
                                        let str =
                                            desc.Scope == eSCOPE.REQUIRED
                                                ? _options.Prefix + desc.Name
                                                : string.Format("[{0}]", _options.Prefix + desc.Name)
                                        select str;

            options = string.Join(" ", names);
            return options;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pOptions">The parser options</param>
        /// <param name="pOutput">The output handler</param>
        /// <param name="pUsageNamed">True to list named parameters in the "usage" description.</param>
        public HelpOutput(CliOptions pOptions, iOutputHandler pOutput, bool pUsageNamed = false)
        {
            _options = pOptions;
            _output = pOutput;
            _usageNamed = pUsageNamed;
        }

        /// <summary>
        /// Displays command line usage.
        /// </summary>
        public void Show(ICollection<Description> pDescriptions)
        {
            string namedUsage = getNamedUsage(pDescriptions);
            string passedUsage = getPassedUsage(pDescriptions);

            _output.WriteLine(string.Format(Properties.Help.Usage, OutputFormatter.ExecutableName(), namedUsage,
                passedUsage));

            int maxNameWidth = getMaxNameWidth(pDescriptions);

            if (pDescriptions.FirstOrDefault(pDesc=>pDesc.Role == eROLE.NAMED) != null)
            {
                _output.WriteLine("");
                _output.WriteLine(Properties.Help.Options);
                _output.WriteLine("");
                foreach (Description desc in from desc in pDescriptions where desc.Role == eROLE.NAMED select desc)
                {
                    Display(maxNameWidth, desc);
                }
            }

            if (pDescriptions.FirstOrDefault(pDesc=>pDesc.Role == eROLE.PASSED) != null)
            {
                _output.WriteLine("");
                foreach (Description desc in from desc in pDescriptions where desc.Role == eROLE.PASSED select desc)
                {
                    Display(maxNameWidth, desc);
                }
            }

            if (pDescriptions.FirstOrDefault(pDesc=>pDesc.Scope == eSCOPE.OPTIONAL) != null)
            {
                _output.WriteLine("");
                _output.WriteLine(Properties.Help.Optional);
            }
        }
    }
}