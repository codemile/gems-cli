using System;
using System.Collections.Generic;
using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Arguments
{
    public static class ArgumentFactory
    {
        /// <summary>
        /// Reads the command line parameters.
        /// </summary>
        public static List<Argument> Create(string pPrefix, string pEquals, IEnumerable<string> pStrings)
        {
            int count = 0;
            int passed = 0;

            List<Argument> arguments = new List<Argument>();

            foreach (string str in pStrings)
            {
                Argument arg = Create(count++, pPrefix, pEquals, str);
                ArgumentPassed argPassed = arg as ArgumentPassed;
                if (argPassed != null)
                {
                    argPassed.Order = passed++;
                }
                arguments.Add(arg);
            }

            return arguments;
        }

        /// <summary>
        /// Creates an argument object from a string.
        /// </summary>
        /// <param name="pIndex">The index of this argument on the command line.</param>
        /// <param name="pPrefix">Prefixed used to match Named parameters.</param>
        /// <param name="pEquals">Character used for assignment of value to Named parameters.</param>
        /// <param name="pArg">The string of argument from the command line.</param>
        public static Argument Create(int pIndex, string pPrefix, string pEquals, string pArg)
        {
            string name = ExtractName(pPrefix, pEquals, pArg);
            string value = ExtractValue(pPrefix, pEquals, pArg);

            if (name == null && value == null)
            {
                throw new InvalidArgumentException(Errors.ArgumentFactoryNull);
            }

            if (name == null)
            {
                return new ArgumentPassed(pIndex, value);
            }

            return new ArgumentNamed(pIndex, name, value);
        }

        /// <summary>
        /// Extracts the name part of the argument.
        /// </summary>
        /// <param name="pPrefix">The prefix to identify a named parameter</param>
        /// <param name="pEquals">The character to split between name and value.</param>
        /// <param name="pArg">The argument value.</param>
        /// <returns>The name part or Null if no name.</returns>
        public static string ExtractName(string pPrefix, string pEquals, string pArg)
        {
            if (!pArg.StartsWith(pPrefix))
            {
                return null;
            }
            string str = pArg.Substring(pPrefix.Length);
            int equal = str.IndexOf(pEquals, StringComparison.Ordinal);
            return equal == -1 ? str.ToLower() : str.Substring(0, equal).ToLower();
        }

        /// <summary>
        /// Extracts the value part of the argument.
        /// </summary>
        /// <param name="pPrefix">The prefix to identify a named parameter</param>
        /// <param name="pEquals">The character to split between name and value.</param>
        /// <param name="pArg">The argument value.</param>
        /// <returns>The value part of Null if no value</returns>
        public static string ExtractValue(string pPrefix, string pEquals, string pArg)
        {
            if (string.IsNullOrEmpty(pArg))
            {
                return null;
            }
            if (!pArg.StartsWith(pPrefix))
            {
                return pArg;
            }
            int equal = pArg.IndexOf(pEquals, StringComparison.Ordinal);
            return equal == -1 ? null : pArg.Substring(equal + pEquals.Length);
        }
    }
}