using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
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
        /// <param name="pValue">The argument value.</param>
        public ArgumentPassed(int pIndex, string pValue)
            : base(pIndex, pValue)
        {
            if (string.IsNullOrEmpty(pValue))
            {
                throw new InvalidArgumentException(Errors.ArgumentNullName);
            }

            Order = 0;
        }

        /// <summary>
        /// Select the one description that best matches this argument, or
        /// none if there is match.
        /// </summary>
        /// <param name="pDescs">A collection of descriptions.</param>
        public override void Attach(IEnumerable<Description> pDescs)
        {
            Description[] passed = (from desc in pDescs
                                    where desc.Role == eROLE.PASSED
                                    select desc).ToArray();
            if (passed.Length == 0 || Order > passed.Length)
            {
                return;
            }
            Desc = passed[Order];
        }
    }
}