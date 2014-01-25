using System.Collections.Generic;
using System.Linq;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;

namespace GemsCLI.Arguments
{
    public sealed class ArgumentList : List<Description>
    {
        /// <summary>
        /// Checks if a named parameter already exists in
        /// the collection.
        /// </summary>
        /// <param name="pName">The name of the parameter.</param>
        /// <returns>True if it exists.</returns>
        private bool Contains(string pName)
        {
            return this.FirstOrDefault(pDesc=>pDesc.Name == pName) != null;
        }

        /// <summary>
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pHelp"></param>
        /// <param name="pType"></param>
        /// <param name="pScope"></param>
        /// <param name="pMultiplicity"></param>
        public void Named(string pName, string pHelp, iParamType pType, eSCOPE pScope = eSCOPE.OPTIONAL,
                          eMULTIPLICITY pMultiplicity = eMULTIPLICITY.SINGLURAL)
        {
            if (Contains(pName))
            {
                throw new ArgumentParserException("Argument {0} already set.", pName);
            }
            Add(new Description(pName, pHelp, pType, pScope, pMultiplicity));
        }

        public void Passed(string pHelp, iParamType pType, eSCOPE pScope = eSCOPE.OPTIONAL,
                           eMULTIPLICITY pMultiplicity = eMULTIPLICITY.SINGLURAL)
        {
            Add(new Description(pHelp, pType, pScope, pMultiplicity));
        }
    }
}