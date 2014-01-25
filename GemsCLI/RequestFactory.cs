using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;

namespace GemsCLI
{
    public static class RequestFactory
    {
        /// <summary>
        /// Reads the command line parameters.
        /// </summary>
        private static IEnumerable<ArgumentValue> SelectValues(ParserOptions pOptions, IEnumerable<string> pArgs)
        {
            int count = 0;
            return from arg in pArgs select new ArgumentValue(count++, pOptions.Prefix, pOptions.EqualChar, arg);
        }

        public static Request Create(ParserOptions pOptions, IEnumerable<string> pArgs)
        {
            List<ArgumentValue> values = SelectValues(pOptions, pArgs).ToList();
            return new Request(values);
        }
    }
}