namespace GemsCLI.Enums
{
    /// <summary>
    /// Different kinds of validation errors.
    /// </summary>
    public enum eERROR
    {
        /// <summary>
        /// A required parameter is missing.
        /// </summary>
        REQUIRED,

        /// <summary>
        /// A parameter occurred more then once, when it should be single.
        /// </summary>
        DUPLICATE,

        /// <summary>
        /// An unknown named parameter was found
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// A named parameter is missing it's value assignment
        /// </summary>
        MISSING_VALUE
    }
}