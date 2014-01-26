using System;

namespace GemsCLI.Attributes
{
    /// <summary>
    /// Adds a help message to a property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CliHelp : Attribute
    {
        /// <summary>
        /// The help message.
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">The help message</param>
        public CliHelp(string pMessage)
        {
            _message = pMessage;
        }
    }
}