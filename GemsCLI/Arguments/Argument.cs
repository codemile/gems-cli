using System.Collections.Generic;
using GemsCLI.Descriptions;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// An object that holds the original value as a string
    /// from the command line.
    /// </summary>
    public abstract class Argument
    {
        /// <summary>
        /// The index of this argument with other arguments.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// The value of the argument, or Null
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// The argument description matched to this argument.
        /// </summary>
        public Description Desc { get; protected set; }

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pValue">(optional)The argument value</param>
        protected Argument(int pIndex, string pValue)
        {
            Index = pIndex;
            Value = pValue;
        }

        /// <summary>
        /// Select the one description that best matches this argument, or
        /// none if there is match.
        /// </summary>
        /// <param name="pDescs">A collection of descriptions.</param>
        /// <returns>True if attached.</returns>
        public abstract void Attach(IEnumerable<Description> pDescs);
    }
}