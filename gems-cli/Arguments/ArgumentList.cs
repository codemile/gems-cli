using System.Collections.Generic;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;

namespace GemsCLI.Arguments
{
    public sealed class ArgumentList
    {
        /// <summary>
        /// A list of arguments.
        /// </summary>
        private readonly Dictionary<string, Description> _arguments;

        /// <summary>
        /// Access a parameter by name.
        /// </summary>
        public string this[string pName]
        {
            get { return _arguments[pName].ToString(); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ArgumentList()
        {
            _arguments = new Dictionary<string, Description>();
        }

        /// <summary>
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pHelp"></param>
        /// <param name="pType"></param>
        /// <param name="pScope"></param>
        /// <param name="pOrdinal"></param>
        public void Add(string pName, string pHelp, iParamType pType, eSCOPE pScope = eSCOPE.OPTIONAL,
                        eORDINAL pOrdinal = eORDINAL.SINGLURAL)
        {
            if (_arguments.ContainsKey(pName))
            {
                throw new ArgumentParserException("Argument {0} already set.", pName);
            }
            _arguments.Add(pName, new Description(pName, pHelp, pType, pScope, pOrdinal));
        }

        /// <summary>
        /// Checks if an argument is set.
        /// </summary>
        public bool Has(string pName)
        {
            return _arguments.ContainsKey(pName) && _arguments[pName].Enabled;
        }
    }
}