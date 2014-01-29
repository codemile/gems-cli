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
        public readonly string Name;

        /// <summary>
        /// The role for this parameter.
        /// </summary>
        public readonly eROLE Role;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pRole"></param>
        /// <param name="pName">The name of the parameter</param>
        public CliName(eROLE pRole = eROLE.NAMED, string pName = null)
        {
            Role = pRole;
            Name = pName;
        }
    }
}