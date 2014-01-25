namespace GemsCLI.Types
{
    public class ParamString : iParamType
    {
        /// <summary>
        /// Default value
        /// </summary>
        private readonly string _default;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDefault">The default value</param>
        public ParamString(string pDefault = "")
        {
            _default = pDefault;
        }
    }
}