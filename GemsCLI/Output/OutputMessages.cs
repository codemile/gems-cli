using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;

namespace GemsCLI.Output
{
    /// <summary>
    /// Sends output for the parser to the console.
    /// </summary>
    public class OutputMessages
    {
        /// <summary>
        /// The parser options.
        /// </summary>
        private readonly CliOptions _options;

        /// <summary>
        /// The output handler.
        /// </summary>
        private readonly iOutputStream _output;

        /// <summary>
        /// Initializes this class
        /// </summary>
        public OutputMessages(CliOptions pOptions, iOutputStream pOutput)
        {
            _options = pOptions;
            _output = pOutput;
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
                    _output.Error(OutputFormatter.WriteRequired(pDesc.Role, _options.Prefix, pDesc.Name));
                    return;
                case eERROR.DUPLICATE:
                    _output.Error(OutputFormatter.WriteDuplicate(pDesc.Role, _options.Prefix, pDesc.Name));
                    return;
                case eERROR.MISSING_VALUE:
                    _output.Error(OutputFormatter.WriteMissingValue(pDesc.Role, _options.Prefix, pDesc.Name));
                    return;
            }

            throw new InvalidArgumentException("Unsupported error type");
        }

        /// <summary>
        /// Called when an argument is not recognized.
        /// </summary>
        /// <param name="pUnknown">The unknown argument.</param>
        public void Unknown(Argument pUnknown)
        {
            _output.Error(OutputFormatter.WriteUnknown(pUnknown.Value));
        }
    }
}