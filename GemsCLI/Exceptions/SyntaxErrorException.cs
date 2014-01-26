namespace GemsCLI.Exceptions
{
    public class SyntaxErrorException : GemsCLIException
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        public SyntaxErrorException(string pMessage, params object[] pValues) : base(pMessage, pValues)
        {
        }
    }
}