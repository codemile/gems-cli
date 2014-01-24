using System.Collections.Generic;
using GemsCLI.Exceptions;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Holds the value of a single command line argument.
    /// </summary>
    public class Argument : IEqualityComparer<Argument>
    {
        /// <summary>
        /// The name of the argument.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The value of the argument.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Constructor
        /// </summary>
        public Argument(string pArg)
        {
            if (!pArg.StartsWith("--"))
            {
                throw new ArgumentParserException("Unsupported or invalid argument: {0}", pArg);
            }

            int first = pArg.IndexOf('=');
            if (first == -1)
            {
                Name = pArg.Substring(2).ToLower();
            }
            else
            {
                Name = pArg.Substring(2, first - 2).ToLower();
                Value = pArg.Substring(first + 1).Trim();
            }
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        public bool Equals(Argument pArg1, Argument pArg2)
        {
            //Check whether the compared objects reference the same data. 
            if (ReferenceEquals(pArg1, pArg2))
            {
                return true;
            }

            //Check whether any of the compared objects is null. 
            if (ReferenceEquals(pArg1, null) || ReferenceEquals(pArg2, null))
            {
                return false;
            }

            //Check whether the products' properties are equal. 
            return pArg1.Name == pArg2.Name;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        public int GetHashCode(Argument pObj)
        {
            return ReferenceEquals(pObj, null) ? 0 : Name.GetHashCode();
        }
    }
}