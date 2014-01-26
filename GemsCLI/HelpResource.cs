using System.Collections.Generic;
using System.Resources;
using GemsCLI.Descriptions;
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
        public readonly List<Description> Descriptions;

        /// <summary>
        /// Reference to resource to find help messages.
        /// </summary>
        private readonly ResourceManager _resource;

        /// <summary>
        /// What to do if help is missing.
        /// </summary>
        private readonly bool _strict;

        /// <summary>
        /// Finds the help message for a parameter
        /// </summary>
        /// <param name="pName">The parameter name</param>
        /// <returns>The help message.</returns>
        private string getHelp(string pName)
        {
            string help = _resource.GetString(pName);
            if (help == null && _strict)
            {
                throw new ArgumentParserException("Help not defined for {0}", pName);
            }
            return help ?? "";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pResource">The manager with help messages.</param>
        /// <param name="pStrict">Controls the throwing of an exception for missing help.</param>
        public HelpResource(ResourceManager pResource, bool pStrict = true)
        {
            _resource = pResource;
            Descriptions = new List<Description>();
            _strict = pStrict;
        }

        /// <summary>
        /// Adds an integer to the collection.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pMin">Min value range</param>
        /// <param name="pMax">Max value range</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Ordinal of the parameter</param>
        public void AddInt(
            string pName,
            int pMin = int.MinValue,
            int pMax = int.MaxValue,
            eSCOPE pScope = eSCOPE.OPTIONAL,
            eMULTIPLICITY pMultiplicity = eMULTIPLICITY.ONCE)
        {
            Description desc = new Description(pName, getHelp(pName), eROLE.NAMED, new ParamInt(pMin, pMax), pScope, pMultiplicity);
            Descriptions.Add(desc);
        }

        /// <summary>
        /// Adds a string to the collection.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Ordinal of the parameter</param>
        public void AddString(string pName, eSCOPE pScope = eSCOPE.OPTIONAL,
                              eMULTIPLICITY pMultiplicity = eMULTIPLICITY.ONCE)
        {
            Description desc = new Description(pName, getHelp(pName), eROLE.NAMED, new ParamString(), pScope, pMultiplicity);
            Descriptions.Add(desc);
        }

        /// <summary>
        /// Adds a description of a parameter. Assumes that the name of the
        /// parameter matches the string resource used for a help message.
        /// </summary>
        /// <param name="pName">Unique name of parameter</param>
        /// <param name="pType">Parameter type</param>
        /// <param name="pScope">Scope of the parameter</param>
        /// <param name="pMultiplicity">Ordinal of the parameter</param>
        public void AddType(string pName, iParamType pType, eSCOPE pScope = eSCOPE.OPTIONAL,
                            eMULTIPLICITY pMultiplicity = eMULTIPLICITY.ONCE)
        {
            Description desc = new Description(pName, getHelp(pName), eROLE.NAMED, pType, pScope, pMultiplicity);
            Descriptions.Add(desc);
        }
    }
}