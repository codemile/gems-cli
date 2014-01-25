namespace GemsCLI.Exceptions
{
    public class ArgumentParserException : GemsCLIException
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        public ArgumentParserException(string pMessage, params object[] pValues)
            : base(string.Format(pMessage, pValues))
        {
        }
    }
}