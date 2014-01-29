using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;

namespace GemsCLI.Output
{
    public interface iOutputHandler
    {
        /// <summary>
        /// Called when a validation fails on the parameters.
        /// </summary>
        /// <param name="pDesc">The description of the failed parameter.</param>
        /// <param name="pError">The type of error.</param>
        void Error(Description pDesc, eERROR pError);

        /// <summary>
        /// Output a line of text to the standard output console.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        void WriteLine(string pStr);

        /// <summary>
        /// Called when an argument is not recognized.
        /// </summary>
        /// <param name="pUnknown">The unknown argument.</param>
        void Unknown(Argument pUnknown);
    }
}