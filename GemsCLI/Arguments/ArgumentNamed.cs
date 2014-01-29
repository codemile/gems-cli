namespace GemsCLI.Arguments
{
    /// <summary>
    /// Identifies an argument as Named
    /// </summary>
    public class ArgumentNamed : Argument
    {
        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pName">The name of the parameter.</param>
        /// <param name="pValue">(optional)The argument value</param>
        public ArgumentNamed(int pIndex, string pName, string pValue)
            : base(pIndex, pName, pValue)
        {
        }
    }
}