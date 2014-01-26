using System;
using GemsCLI.Enums;

namespace GemsCLI.Attributes
{
    /// <summary>
    /// Marks a property as being a Named parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CliName : Attribute
    {
        /// <summary>
        /// The name or Null to use property name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The role for this parameter.
        /// </summary>
        private readonly eROLE _role;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pRole"></param>
        /// <param name="pName">The name of the parameter</param>
        public CliName(eROLE pRole = eROLE.NAMED, string pName = null)
        {
            _role = pRole;
            _name = pName;
        }
    }
}