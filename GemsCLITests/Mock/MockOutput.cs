using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Output;

namespace GemsCLITests.Mock
{
    public class MockOutput : iOutputHandler
    {
        public readonly StringWriter Writer;

        /// <summary>
        /// Constructor
        /// </summary>
        public MockOutput()
        {
            Writer = new StringWriter();
        }

        /// <summary>
        /// Called when a validation fails on the parameters.
        /// </summary>
        /// <param name="pDesc">The description of the failed parameter.</param>
        /// <param name="pError">The type of error.</param>
        public void Error(Description pDesc, eERROR pError)
        {
            Writer.WriteLine(pError.ToString());
        }

        /// <summary>
        /// Output a line of text to the standard output console.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void WriteLine(string pStr)
        {
            Writer.WriteLine(pStr);
        }

        /// <summary>
        /// Gets the text lines (excluding blanks and extra spaces).
        /// </summary>
        /// <returns>An array of strings</returns>
        public string[] getLines()
        {
            string[] lines = Writer.ToString().Split('\n');
            return (from line in lines
                    let str = line.Trim()
                    where !string.IsNullOrWhiteSpace(str)
                    select Regex.Replace(str,@"\s+"," ")).ToArray();
        }
    }
}