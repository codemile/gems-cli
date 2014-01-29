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
        public readonly string Message;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMessage">The help message</param>
        public CliHelp(string pMessage)
        {
            if (string.IsNullOrWhiteSpace(pMessage))
            {
                throw new ArgumentNullException("pMessage",@"Help messages can not be empty.");
            }
            Message = pMessage;
        }
    }
}