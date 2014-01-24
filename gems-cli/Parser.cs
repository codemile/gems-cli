using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;
using GemsCLI.Exceptions;

namespace GemsCLI
{
    /// <summary>
    /// Converts a collection of strings into a collection
    /// of parameter values.
    /// 
    /// A collection of parameter descriptions is used to
    /// perform data validation on the input strings.
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
        private static List<ArgumentValue> CreateValues(ParserOptions pOptions, IEnumerable<string> pArgs)
        {
            return (from arg in pArgs select new ArgumentValue(pOptions.Prefix, pOptions.EqualChar, arg)).ToList();
        }

        /// <summary>
        /// Initializes a new instance of GemsCLI.Parser
        /// </summary>
        /// <param name="pOptions">The options for parsing.</param>
        /// <param name="pArgumentList">List of argument descriptions.</param>
        /// <param name="pArgs">Parameter strings from the command line.</param>
        public Parser(ParserOptions pOptions, ArgumentList pArgumentList, IEnumerable<string> pArgs)
        {
            _options = pOptions;
            _argumentList = pArgumentList;
            _values = CreateValues(pOptions, pArgs);
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