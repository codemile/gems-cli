using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Attributes;
using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Helper
{
    /// <summary>
    /// Uses reflection on an object's type to find help for arguments.
    /// </summary>
    public class HelpReflection : iHelpProvider
    {
        /// <summary>
        /// The source of help messages.
        /// </summary>
        private readonly Dictionary<string, string> _help;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pType">The type to inspect</param>
        public HelpReflection(Type pType)
        {
            _help = (from prop in pType.GetProperties()
                     from attr in prop.GetCustomAttributes(true)
                     let help = attr as CliHelp
                     where help != null
                     select new {help.Message, Name = prop.Name.ToLower()})
                .ToDictionary(pKey=>pKey.Name, pValue=>pValue.Message);

            if (_help.Count == 0)
            {
                throw new InvalidArgumentException("Type does not contain any help.");
            }
        }

        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        public string Get(string pName)
        {
            if (!_help.ContainsKey(pName))
            {
                throw new HelpException(Errors.HelpNotFound, pName);
            }
            return _help[pName];
        }
    }
}