using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Exceptions;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Handles converting command line arguments into a collection that
    /// can be used.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// A list of arguments.
        /// </summary>
        private readonly Dictionary<string, ArgumentValue> _arguments;

        /// <summary>
        /// Access a parameter by name.
        /// </summary>
        public string this[string pName]
        {
            get { return _arguments[pName].ToString(); }
        }

        /// <summary>
        /// Checks if an argument is set.
        /// </summary>
        public bool Has(string pName)
        {
            return _arguments.ContainsKey(pName) && _arguments[pName].Enabled;
        }

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
        public Parser()
        {
            _arguments = new Dictionary<string, ArgumentValue>();
        }

        /// <summary>
        /// Adds a description of a parameter.
        /// </summary>
        public void Param(string pName, string pHelp, bool pNeedValue, bool pRequired, string pDefault = "")
        {
            _arguments.Add(pName, new ArgumentValue(pName, pNeedValue, pRequired, pHelp, pDefault));
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

        /// <summary>
        /// Parses the command line parameters.
        /// </summary>
        public void Parse(ICollection<string> pArgs)
        {
            Dictionary<string, Argument> args = (from arg in pArgs select new Argument(arg))
                .Distinct()
                .ToDictionary(pArg => pArg.Name);

            if (args.Count != pArgs.Count)
            {
                throw new ArgumentParserException("Duplicate arguments not supported.");
            }

            foreach (KeyValuePair<string, Argument> pair in args)
            {
                if (!_arguments.ContainsKey(pair.Key))
                {
                    throw new ArgumentParserException("ERROR: --{0} is not a supported argument.", pair.Key);
                }
                _arguments[pair.Key].Set(pair.Value.Value);
            }
        }

        /// <summary>
        /// Validates that the arguments are used correctly.
        /// </summary>
        public void Validate()
        {
            bool error = false;

            // check missing required parameters
            foreach (string name in from x in _arguments.Values where x.Required && !x.Enabled select x.Name)
            {
                Console.Error.WriteLine("ERROR: Argument --{0} is required.", name);
                error = true;
            }

            // check for incorrectly assigned value
            foreach (string name in from x in _arguments.Values where x.Enabled && !x.NeedsValue && x.isSet() select x.Name)
            {
                Console.Error.WriteLine("ERROR: --{0} does not take a value.", name);
                error = true;
            }

            // check for required values
            foreach (string name in from x in _arguments.Values where x.Enabled && x.NeedsValue && !x.isSet() select x.Name)
            {
                Console.Error.WriteLine("ERROR: --{0} requires a value be assigned using =.", name);
                error = true;
            }

            if (error)
            {
                throw new ArgumentParserException("Argument parsing error.");
            }
        }

        /// <summary>
        /// Displays command line usage.
        /// </summary>
        public void ShowHelp(string pAppName)
        {
            const int chunkSize = 80;

            Console.WriteLine(@"Usage: {0} [OPTIONS]", pAppName);
            Console.WriteLine();

            int width = (from name in _arguments.Keys select name.Length).Max() + 1;

            foreach (ArgumentValue value in _arguments.Values)
            {
                string str = value.Help;
                string[] lines = SplitByLength(str, chunkSize).ToArray();
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(i == 0 ? @"--{0} {1}" : "{2} {1}", value.Name.PadRight(width), lines[i],
                        new String(' ', width));
                }
            }
        }
    }
}