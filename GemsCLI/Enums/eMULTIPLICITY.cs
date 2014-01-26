namespace GemsCLI.Enums
{
    /// <summary>
    /// How many times a parameter is allowed to occur.
    /// </summary>
    public enum eMULTIPLICITY
    {
        /// <summary>
        /// Once, any more will result in an error
        /// </summary>
        ONCE,

        /// <summary>
        /// One or more times (results in a collection)
        /// </summary>
        MULTIPLE
    }
}