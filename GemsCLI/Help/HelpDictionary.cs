using System.Collections.Generic;
using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Help
{
    public class HelpDictionary : Dictionary<string, string>, iHelpProvider
    {
        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        public string Get(string pName)
        {
            if (ContainsKey(pName))
            {
                return this[pName];
            }
            throw new HelpException(Errors.HelpNotFound, pName);
        }
    }
}