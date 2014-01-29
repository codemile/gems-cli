using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;

namespace GemsCLI
{
    public sealed class Request : List<Argument>
    {
        /// <summary>
        /// Selects all the Named arguments that match the name key.
        /// </summary>
        /// <param name="pNamed">The name of the argument.</param>
        /// <returns>A collection of arguments for that name</returns>
        public List<Argument> this[string pNamed]
        {
            get
            {
                return (from value in this
                        where string.Compare(value.Name, pNamed, StringComparison.OrdinalIgnoreCase) == 0
                        select value).ToList();
            }
        }

        /// <summary>
        /// Initializes the class with a collection of values.
        /// </summary>
        /// <param name="pValues">Collection of argument values.</param>
        public Request(IEnumerable<Argument> pValues)
            : base(pValues)
        {
        }

        /// <summary>
        /// Checks if the request contains a Named parameter.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>True if at least one exists.</returns>
        public bool Contains(string pName)
        {
            return this.Any(pValue=>pValue.Name == pName);
        }

        /// <summary>
        /// Counts have many Named parameters there are.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>How many times this named parameter exists in the request.</returns>
        public int Count(string pName)
        {
            return this.Count(pValue=>pValue.Name == pName);
        }
    }
}