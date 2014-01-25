using System.Collections.Generic;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;

namespace GemsCLI
{
    /// <summary>
    /// Converts a collection of strings into a collection
    /// of parameter values.
    /// A collection of parameter descriptions is used to
    /// perform data validation on the input strings.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// A list of arguments that are allowed.
        /// </summary>
        private readonly DescriptionList _descriptionList;

        /// <summary>
        /// Configures how parameters are formatted.
        /// </summary>
        private readonly ParserOptions _options;

        /// <summary>
        /// The request object that represents the parameter arguments.
        /// </summary>
        public Request Request { get; set; }

        /// <summary>
        /// Initializes a new instance of GemsCLI.Parser
        /// </summary>
        /// <param name="pOptions">The options for parsing.</param>
        /// <param name="pDescriptionList">List of argument descriptions.</param>
        /// <param name="pArgs">Parameter strings from the command line.</param>
        public Parser(ParserOptions pOptions, DescriptionList pDescriptionList, IEnumerable<string> pArgs)
        {
            _options = pOptions;
            _descriptionList = pDescriptionList;

            IEnumerable<Argument> arguments = ArgumentFactory.Create(pOptions.Prefix, pOptions.EqualChar, pArgs);
            Request = new Request(arguments);
        }
    }
}