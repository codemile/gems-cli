using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Identifies an argument as Named
    /// </summary>
    public class ArgumentNamed : Argument
    {
        /// <summary>
        /// The name of the argument.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pName">The name of the parameter.</param>
        /// <param name="pValue">(optional)The argument value</param>
        public ArgumentNamed(int pIndex, string pName, string pValue)
            : base(pIndex, pValue)
        {
            if (string.IsNullOrWhiteSpace(pName))
            {
                throw new InvalidArgumentException(Errors.ArgumentNullName);
            }
            Name = pName;
        }

        /// <summary>
        /// Select the first Named description where the names match.
        /// </summary>
        /// <param name="pDescs">A collection of descriptions.</param>
        public override void Attach(IEnumerable<Description> pDescs)
        {
            Desc = pDescs.FirstOrDefault(pDesc=>pDesc.Role == eROLE.NAMED &&
                    string.Compare(pDesc.Name, Name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}