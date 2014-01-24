using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;
using GemsCLI.Exceptions;

namespace GemsCLI
{
    /// <summary>
    /// Handles converting command line arguments into a collection that
    /// can be used.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// A list of arguments that are allowed.
        /// </summary>
        private readonly ArgumentList _argumentList;

        /// <summary>
        /// Configures how parameters are formatted.
        /// </summary>
        private readonly ParserOptions _options;

        /// <summary>
        /// Values from the command line.
        /// </summary>
        private readonly List<ArgumentValue> _values;

        /// <summary>
        /// Reads the command line parameters.
        /// </summary>
        private static List<ArgumentValue> Read(IEnumerable<string> pArgs)
        {
            return (from arg in pArgs select new ArgumentValue(arg)).ToList();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser(ParserOptions pOptions, ArgumentList pArgumentList, IEnumerable<string> pArgs)
        {
            _options = pOptions;
            _argumentList = pArgumentList;
            _values = Read(pArgs);
        }

        /// <summary>
        /// Sets the value for the parameter.
        /// </summary>
        public static KeyValuePair<string, string> Split(string pArg)
        {
            if (!pArg.StartsWith("--") || !pArg.Contains("="))
            {
                throw new ArgumentParserException("Unsupported or invalid argument: {0}", pArg);
            }

            int delimiter = pArg.IndexOf('=');
            if (delimiter == -1)
            {
                return new KeyValuePair<string, string>(pArg.Substring(3).ToLower(), "");
            }

            string strName = pArg.Substring(3, delimiter).ToLower();
            string strValue = pArg.Substring(delimiter).Trim();
            return new KeyValuePair<string, string>(strName, strValue);
        }

        public void Dispatch()
        {
        }
    }
}