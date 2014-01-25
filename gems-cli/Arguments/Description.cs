using GemsCLI.Enums;
using GemsCLI.Types;

namespace GemsCLI.Arguments
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
        /// Is this a Named parameter?
        /// </summary>
        public bool isNamed
        {
            get { return Name != null; }
        }

        /// <summary>
        /// Is this a Passed parameter?
        /// </summary>
        public bool isPassed
        {
            get { return !isNamed; }
        }

        /// <summary>
        /// Initializes the class to represent a passed parameter.
        /// </summary>
        /// <param name="pHelp">Help message</param>
        /// <param name="pType">Value type converter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Number of occurrences</param>
        public Description(string pHelp, iParamType pType, eSCOPE pScope, eMULTIPLICITY pMultiplicity)
            : this(null, pHelp, pType, pScope, pMultiplicity)
        {
        }

        /// <summary>
        /// Initializes the class to represent a named parameter.
        /// </summary>
        /// <param name="pName">Name of the parameter</param>
        /// <param name="pHelp">Help message</param>
        /// <param name="pType">Value type converter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Number of occurrences</param>
        public Description(string pName, string pHelp, iParamType pType, eSCOPE pScope, eMULTIPLICITY pMultiplicity)
        {
            Name = pName;
            Help = pHelp;
            Type = pType;
            Scope = pScope;
            Multiplicity = pMultiplicity;
        }
    }
}