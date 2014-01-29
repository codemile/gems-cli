using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// An object that holds the original value as a string
    /// from the command line.
    /// </summary>
    public abstract class Argument
    {
        /// <summary>
        /// The name of the argument.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The index of this argument with other arguments.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// The value of the argument, or Null
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pName">The name of the parameter.</param>
        /// <param name="pValue">(optional)The argument value</param>
        protected Argument(int pIndex, string pName, string pValue)
        {
            if (string.IsNullOrWhiteSpace(pName))
            {
                throw new InvalidArgumentException(Errors.ArgumentNullName);
            }
            Name = pName;
            Index = pIndex;
            Value = pValue;
        }
    }
}