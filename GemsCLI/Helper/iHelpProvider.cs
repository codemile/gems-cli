namespace GemsCLI.Helper
{
    /// <summary>
    /// Providers the help messages for parameter.
    /// </summary>
    public interface iHelpProvider
    {
        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        string Get(string pName);
    }
}