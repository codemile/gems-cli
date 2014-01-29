using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Identifies an argument as Passed
    /// </summary>
    public class ArgumentPassed : Argument
    {
        /// <summary>
        /// The order of this Passed parameter relative to the first Passed parameter.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The position relative to other passed arguments.</param>
        /// <param name="pName">The name of the parameter.</param>
        /// <param name="pValueType">The argument value.</param>
        public ArgumentPassed(int pIndex, string pName, string pValueType)
            : base(pIndex, pName, pValueType)
        {
            if (string.IsNullOrEmpty(pValueType))
            {
                throw new InvalidArgumentException(Errors.ArgumentNullName);
            }

            Order = 0;
        }
    }
}