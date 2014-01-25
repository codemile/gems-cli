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
        public List<ArgumentNamed> this[string pNamed]
        {
            get
            {
                return (from value in this
                        let named = value as ArgumentNamed
                        where
                            named != null &&
                            named.Name == pNamed
                        select named).ToList();
            }
        }

        /// <summary>
        /// A collection of Named parameter values.
        /// </summary>
        public List<ArgumentNamed> Named
        {
            get
            {
                return (from value in this
                        let named = value as ArgumentNamed
                        where named != null
                        select named).ToList();
            }
        }

        /// <summary>
        /// A collection of Passed parameter values.
        /// </summary>
        public List<ArgumentPassed> Passed
        {
            get
            {
                return (from value in this
                        let passed = value as ArgumentPassed
                        where passed != null
                        select passed).ToList();
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
            return this.FirstOrDefault(
                pValue=>pValue is ArgumentNamed &&
                        ((ArgumentNamed)pValue).Name == pName) != null;
        }

        /// <summary>
        /// Counts have many Named parameters there are.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>How many times this named parameter exists in the request.</returns>
        public int Count(string pName)
        {
            return this.Count(pValue=>pValue is ArgumentNamed &&
                                      ((ArgumentNamed)pValue).Name == pName);
        }
    }
}