using System.Resources;
using GemsCLI.Arguments;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;

namespace GemsCLI
{
    public class HelpResource
    {
        /// <summary>
        /// The arguments collection
        /// </summary>
        public readonly ArgumentList ArgumentList;

        /// <summary>
        /// Reference to resource to find help messages.
        /// </summary>
        private readonly ResourceManager _resource;

        /// <summary>
        /// Finds the help message for a parameter
        /// </summary>
        /// <param name="pName">The parameter name</param>
        /// <returns>The help message.</returns>
        private string getHelp(string pName)
        {
            string help = _resource.GetString(pName);
            if (help == null)
            {
                throw new ArgumentParserException("Help not defined for {0}", pName);
            }
            return help;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pResource">The manager with help messages.</param>
        /// <param name="pArgumentList">The arguments collection.</param>
        public HelpResource(ResourceManager pResource, ArgumentList pArgumentList)
        {
            _resource = pResource;
            ArgumentList = pArgumentList;
        }

        /// <summary>
        /// Adds an integer to the collection.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pMin">Min value range</param>
        /// <param name="pMax">Max value range</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pOrdinal">Ordinal of the parameter</param>
        public void AddInt(
            string pName,
            int pMin = int.MinValue,
            int pMax = int.MaxValue,
            eSCOPE pScope = eSCOPE.OPTIONAL,
            eORDINAL pOrdinal = eORDINAL.SINGLURAL)
        {
            ArgumentList.Add(pName, getHelp(pName), new ParamInt(pMin, pMax), pScope, pOrdinal);
        }

        /// <summary>
        /// Adds a string to the collection.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pOrdinal">Ordinal of the parameter</param>
        public void AddString(string pName, eSCOPE pScope = eSCOPE.OPTIONAL,
                              eORDINAL pOrdinal = eORDINAL.SINGLURAL)
        {
            ArgumentList.Add(pName, getHelp(pName), new ParamString(), pScope, pOrdinal);
        }

        /// <summary>
        /// Adds a description of a parameter. Assumes that the name of the
        /// parameter matches the string resource used for a help message.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pType">Parameter type</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pOrdinal">Ordinal of the parameter</param>
        public void AddType(string pName, iParamType pType, eSCOPE pScope = eSCOPE.OPTIONAL,
                            eORDINAL pOrdinal = eORDINAL.SINGLURAL)
        {
            ArgumentList.Add(pName, getHelp(pName), pType, pScope, pOrdinal);
        }
    }
}