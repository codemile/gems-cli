using System.Diagnostics;
using System.Text.RegularExpressions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Properties;
using GemsCLI.Types;

namespace GemsCLI.Descriptions
{
    /// <summary>
    /// Describes the traits of an argument.
    /// </summary>
    [DebuggerDisplay("{Name} {Role}/{Scope}")]
    public class Description
    {
        /// <summary>
        /// The help message for the argument.
        /// </summary>
        public readonly string Help;

        /// <summary>
        /// The ordinal rule for the parameter.
        /// </summary>
        public readonly eMULTIPLICITY Multiplicity;

        /// <summary>
        /// The name of the argument.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Is this a Named or Passed parameter
        /// </summary>
        public readonly eROLE Role;

        /// <summary>
        /// The scope of the parameter.
        /// </summary>
        public readonly eSCOPE Scope;

        /// <summary>
        /// The type converter for the parameter.
        /// </summary>
        public readonly iParamType Type;

        /// <summary>
        /// Initializes the class to represent a named parameter.
        /// </summary>
        /// <param name="pName">Name of the parameter</param>
        /// <param name="pHelp">Help message</param>
        /// <param name="pRole">Named or Passed parameter</param>
        /// <param name="pType">Value type converter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Number of occurrences</param>
        /// <exception cref="SyntaxErrorException">Thrown if there is an invalid parameter.</exception>
        public Description(string pName, string pHelp, eROLE pRole, iParamType pType, eSCOPE pScope,
                           eMULTIPLICITY pMultiplicity)
        {
            if (string.IsNullOrWhiteSpace(pName))
            {
                throw new SyntaxErrorException(Errors.DescriptionName);
            }

            if (string.IsNullOrWhiteSpace(pHelp))
            {
                throw new SyntaxErrorException(Errors.DescriptionHelp);
            }

            if (pRole == eROLE.NAMED && pType == null && pMultiplicity == eMULTIPLICITY.MULTIPLE)
            {
                throw new SyntaxErrorException(Errors.DescriptionSingle);
            }

            if (pRole == eROLE.PASSED && pType == null)
            {
                throw new SyntaxErrorException(Errors.DescriptionTypeRequired);
            }

            if (!Regex.IsMatch(pName, @"^[a-z_]\w*$", RegexOptions.IgnoreCase))
            {
                throw new SyntaxErrorException(Errors.DescriptionInvalidName);
            }

            Name = pName.ToLower();
            Help = pHelp;
            Role = pRole;
            Type = pType;
            Scope = pScope;
            Multiplicity = pMultiplicity;
        }
    }
}