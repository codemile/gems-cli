using System.Resources;
using GemsCLI.Exceptions;
using GemsCLI.Properties;

namespace GemsCLI.Helper
{
    /// <summary>
    /// Uses a string resource to read help messages.
    /// </summary>
    public class HelpResource : iHelpProvider
    {
        /// <summary>
        /// Reference to resource to find help messages.
        /// </summary>
        private readonly ResourceManager _resource;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pResource">The manager with help messages.</param>
        public HelpResource(ResourceManager pResource)
        {
            _resource = pResource;
        }

        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        public string Get(string pName)
        {
            _resource.IgnoreCase = true;
            string help = _resource.GetString(pName);
            if (string.IsNullOrWhiteSpace(help))
            {
                throw new HelpException(Errors.HelpNotFound, pName);
            }
            return help;
        }
    }
}