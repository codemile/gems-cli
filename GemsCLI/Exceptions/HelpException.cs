namespace GemsCLI.Exceptions
{
    public class HelpException : GemsCLIException
    {
        /// <summary>
        /// String Format constructor
        /// </summary>
        public HelpException(string pMessage, params object[] pValues)
            : base(string.Format(pMessage, pValues))
        {
        }
    }
}