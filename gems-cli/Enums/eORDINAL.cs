namespace GemsCLI.Enums
{
    /// <summary>
    /// How many times a parameter is allowed to occur.
    /// </summary>
    public enum eORDINAL
    {
        /// <summary>
        /// Once, any more will result in an error
        /// </summary>
        SINGLURAL,

        /// <summary>
        /// One or more times (results in a collection)
        /// </summary>
        MULTIPLE
    }
}