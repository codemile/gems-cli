using System;

namespace GemsCLI.Exceptions
{
    public abstract class GemsCLIException : Exception
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        protected GemsCLIException(string pMessage, params object[] pValues)
            : base(string.Format(pMessage, pValues))
        {
        }
    }
}