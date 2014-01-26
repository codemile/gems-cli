using System.Text.RegularExpressions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;

namespace GemsCLI.Descriptions
{
    /// <summary>
    /// Describes the traits of an argument.
    /// </summary>
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
        /// The scope of the parameter.
        /// </summary>
        public readonly eSCOPE Scope;

        /// <summary>
        /// The type converter for the parameter.
        /// </summary>
        public readonly iParamType Type;

        /// <summary>
        /// Is this a Named or Passed parameter
        /// </summary>
        public readonly eROLE Role;

        /// <summary>
        /// Initializes the class to represent a named parameter.
        /// </summary>
        /// <param name="pName">Name of the parameter</param>
        /// <param name="pHelp">Help message</param>
        /// <param name="pRole">Named or Passed parameter</param>
        /// <param name="pType">Value type converter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Number of occurrences</param>
        public Description(string pName, string pHelp, eROLE pRole, iParamType pType, eSCOPE pScope, eMULTIPLICITY pMultiplicity)
        {
            if (string.IsNullOrWhiteSpace(pName))
            {
                throw new SyntaxErrorException("Parameter must have name.");
            }

            if (pRole == eROLE.NAMED && pType == null && pMultiplicity == eMULTIPLICITY.MULTIPLE)
            {
                throw new SyntaxErrorException("Named parameters without values can not be multiple.");
            }

            if (!Regex.IsMatch(pName, @"^[a-z_]\w*$", RegexOptions.IgnoreCase))
            {
                throw new SyntaxErrorException("Name must start with letter, and contain alphanumeric only.");
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