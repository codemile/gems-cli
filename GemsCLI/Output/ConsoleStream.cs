using System;

namespace GemsCLI.Output
{
    public class ConsoleStream : iOutputStream
    {
        /// <summary>
        /// Outputs a single line of text to the error stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Error(string pStr)
        {
            Console.Error.WriteLine(pStr);
        }

        /// <summary>
        /// Outputs a single line of text to the standard stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Standard(string pStr)
        {
            Console.Out.WriteLine(pStr);
        }
    }
}