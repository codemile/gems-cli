using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GemsCLI.Output;

namespace GemsCLITests.Mock
{
    public class MockOutput : iOutputStream, IDisposable
    {
        private StringWriter _writer;

        /// <summary>
        /// Constructor
        /// </summary>
        public MockOutput()
        {
            _writer = new StringWriter();
        }

        public void Clear()
        {
            Dispose();
            _writer = new StringWriter();
        }

        /// <summary>
        /// Outputs a single line of text to the error stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Error(string pStr)
        {
            _writer.WriteLine(pStr);
        }

        /// <summary>
        /// Outputs a single line of text to the standard stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Standard(string pStr)
        {
            _writer.WriteLine(pStr);
        }

        /// <summary>
        /// Gets the text lines (excluding blanks and extra spaces).
        /// </summary>
        /// <returns>An array of strings</returns>
        public string[] getLines()
        {
            string[] lines = _writer.ToString().Split('\n');
            return (from line in lines
                    let str = line.Trim()
                    where !string.IsNullOrWhiteSpace(str)
                    select Regex.Replace(str, @"\s+", " ")).ToArray();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}