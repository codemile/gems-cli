using System;

namespace GemsCLI.Exceptions
{
    public class ArgumentParserException : Exception
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        public ArgumentParserException(string pMessage, params object[] pValues)
            : base(string.Format(pMessage, pValues))
        {
        }

        /// <summary>
        /// Inner exception constructor
        /// </summary>
        public ArgumentParserException(string pMessage, Exception pInner)
            : base(pMessage, pInner)
        {
        }
    }
}