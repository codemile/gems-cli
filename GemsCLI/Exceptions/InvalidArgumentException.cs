namespace GemsCLI.Exceptions
{
    public class InvalidArgumentException : GemsCLIException
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        public InvalidArgumentException(string pMessage, params object[] pValues) : base(pMessage, pValues)
        {
        }
    }
}