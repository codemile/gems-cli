namespace GemsCLI.Output
{
    public interface iOutputStream
    {
        /// <summary>
        /// Outputs a single line of text to the error stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        void Error(string pStr);

        /// <summary>
        /// Outputs a single line of text to the standard stream.
        /// </summary>
        /// <param name="pStr">The string to write.</param>
        void Standard(string pStr);
    }
}