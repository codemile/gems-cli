using GemsCLI.Exceptions;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Holds the value of a single command line argument.
    /// </summary>
    public class ArgumentValue
    {
        /// <summary>
        /// The help message for the argument.
        /// </summary>
        public readonly string Help;

        /// <summary>
        /// The name of the argument.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Does the argument require a value
        /// </summary>
        public readonly bool NeedsValue;

        /// <summary>
        /// If this argument required.
        /// </summary>
        public readonly bool Required;

        /// <summary>
        /// The value of the argument.
        /// </summary>
        private string _value;

        /// <summary>
        /// Is the argument set on the command line.
        /// </summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ArgumentValue(string pName, bool pNeedsValue, bool pRequired, string pHelp, string pValue)
        {
            Name = pName;
            NeedsValue = pNeedsValue;
            Required = pRequired;
            Help = pHelp;
            Enabled = false;
            _value = pValue;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(_value) ? "" : _value;
        }

        /// <summary>
        /// Sets the value for an argument.
        /// </summary>
        public void Set(string pValue)
        {
            Enabled = true;
            _value = pValue;
            if (!NeedsValue && !string.IsNullOrWhiteSpace(pValue))
            {
                throw new ArgumentParserException("--{0} does not take a value.", Name);
            }
        }

        public bool isSet()
        {
            return !string.IsNullOrWhiteSpace(_value);
        }

        /// <summary>
        /// Checks if the parameter is in a valid state.
        /// </summary>
        public bool isValid()
        {
            if (!Required && !Enabled)
            {
                return true;
            }

            if (Required && !Enabled)
            {
                return false;
            }

            return NeedsValue ? !string.IsNullOrWhiteSpace(_value) : string.IsNullOrWhiteSpace(_value);
        }
    }
}