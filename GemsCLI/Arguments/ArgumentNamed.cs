using GemsCLI.Exceptions;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Identifies an argument as Named
    /// </summary>
    public class ArgumentNamed : Argument
    {
        /// <summary>
        /// The name of the argument, or Null.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pName">The name of the parameter.</param>
        /// <param name="pValue">(optional)The argument value</param>
        public ArgumentNamed(int pIndex, string pName, string pValue)
            : base(pIndex, pValue)
        {
            if (string.IsNullOrWhiteSpace(pName))
            {
                throw new InvalidArgumentException("Empty or Null name value not allowed.");
            }
            Name = pName;
        }
    }
}