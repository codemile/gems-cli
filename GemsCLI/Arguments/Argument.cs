namespace GemsCLI.Arguments
{
    /// <summary>
    /// An object that holds the original value as a string
    /// from the command line.
    /// </summary>
    public abstract class Argument
    {
        /// <summary>
        /// The index of this argument with other arguments.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// The value of the argument, or Null
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Does this argument have a value
        /// </summary>
        public bool HasValue
        {
            get { return Value != null; }
        }

        /// <summary>
        /// Initializes the class
        /// </summary>
        /// <param name="pIndex">The arguments index</param>
        /// <param name="pValue">(optional)The argument value</param>
        protected Argument(int pIndex, string pValue)
        {
            Index = pIndex;
            Value = pValue;
        }
    }
}