using System;
using System.Collections.Generic;
using System.Linq;
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
            string help = (from pair in this
                           where string.Compare(pair.Key, pName, StringComparison.CurrentCultureIgnoreCase) == 0
                           select pair.Value).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(help))
            {
                throw new HelpException(Errors.HelpNotFound, pName);
            }
            return help;
        }
    }
}