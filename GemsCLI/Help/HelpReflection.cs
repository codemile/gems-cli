using System;

namespace GemsCLI.Help
{
    /// <summary>
    /// Uses reflection on an object's type to find help for arguments.
    /// </summary>
    public class HelpReflection : iHelpProvider
    {
        /// <summary>
        /// The source of help messages.
        /// </summary>
        private readonly Type _type;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pType">The type to inspect</param>
        public HelpReflection(Type pType)
        {
            _type = pType;
        }

        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        public string Get(string pName)
        {
            return "There is no help for this option.";
        }
    }
}