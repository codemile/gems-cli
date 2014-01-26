using System;
using GemsCLI.Descriptions;
using GemsCLI.Enums;

namespace GemsCLI.Output
{
    /// <summary>
    /// Sends output for the parser to the console.
    /// </summary>
    public class ConsoleOutput : iOutputHandler
    {
        /// <summary>
        /// The parser options.
        /// </summary>
        private readonly ParserOptions _options;

        /// <summary>
        /// Initializes this class
        /// </summary>
        public ConsoleOutput(ParserOptions pOptions)
        {
            _options = pOptions;
        }

        /// <summary>
        /// Called when a validation fails on the parameters.
        /// </summary>
        /// <param name="pDesc">The description of the failed parameter.</param>
        /// <param name="pError">The type of error.</param>
        public void Error(Description pDesc, eERROR pError)
        {
            switch (pError)
            {
                case eERROR.REQUIRED:
                    Console.Error.WriteLine(OutputFormatter.WriteRequired(pDesc.Role, _options.Prefix, pDesc.Name));
                    return;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Output a line of text to the standard output console.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void WriteLine(string pStr)
        {
            Console.WriteLine(pStr);
        }
    }
}