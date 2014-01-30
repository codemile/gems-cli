using System.Diagnostics;

namespace GemsCLI.Output
{
    public class DebugStream : iOutputStream
    {
        /// <summary>
        /// Outputs a single line of text to the error stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Error(string pStr)
        {
            Debug.WriteLine(string.Format("ERROR:{0}", pStr));
        }

        /// <summary>
        /// Outputs a single line of text to the standard stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        public void Standard(string pStr)
        {
            Debug.WriteLine(pStr);
        }
    }
}