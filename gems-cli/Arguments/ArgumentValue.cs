using System;
using System.Collections.Generic;

namespace GemsCLI.Arguments
{
    /// <summary>
    /// Holds the value of a single command line argument.
    /// </summary>
    internal class ArgumentValue : IEqualityComparer<ArgumentValue>
    {
        /// <summary>
        /// The name of the argument, or Null.
        /// </summary>
        public readonly string Name;

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
        /// Is this a named argument
        /// </summary>
        public bool isNamed
        {
            get { return Name != null; }
        }

        /// <summary>
        /// Extracts the name part of the argument.
        /// </summary>
        /// <param name="pPrefix">The prefix to identify a named parameter</param>
        /// <param name="pEquals">The character to split between name and value.</param>
        /// <param name="pArg">The argument value.</param>
        /// <returns>The name part or Null if no name.</returns>
        private static string ExtractName(string pPrefix, string pEquals, string pArg)
        {
            if (!pArg.StartsWith(pPrefix))
            {
                return null;
            }
            string str = pArg.Substring(pPrefix.Length);
            int equal = str.IndexOf(pEquals, StringComparison.Ordinal);
            return equal == -1 ? str.ToLower() : str.Substring(0, equal).ToLower();
        }

        /// <summary>
        /// Extracts the value part of the argument.
        /// </summary>
        /// <param name="pPrefix">The prefix to identify a named parameter</param>
        /// <param name="pEquals">The character to split between name and value.</param>
        /// <param name="pArg">The argument value.</param>
        /// <returns>The value part of Null if no value</returns>
        private static string ExtractValue(string pPrefix, string pEquals, string pArg)
        {
            if (!pArg.StartsWith(pPrefix))
            {
                return pArg;
            }
            int equal = pArg.IndexOf(pEquals, StringComparison.Ordinal);
            return equal == -1 ? null : pArg.Substring(equal + pEquals.Length);
        }

        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        public ArgumentValue(string pPrefix, string pEquals, string pArg)
        {
            Name = ExtractName(pPrefix, pEquals, pArg);
            Value = ExtractValue(pPrefix, pEquals, pArg);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        public bool Equals(ArgumentValue pArg1, ArgumentValue pArg2)
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

            //Check whether the properties are equal. 
            return pArg1.Name.Equals(pArg2.Name) && pArg1.Value == pArg2.Value;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        public int GetHashCode(ArgumentValue pObj)
        {
            if (ReferenceEquals(pObj, null))
            {
                return 0;
            }
            int name = (Name == null) ? 0 : Name.GetHashCode();
            int value = (Value == null) ? 0 : Value.GetHashCode();
            return name ^ value;
        }
    }
}