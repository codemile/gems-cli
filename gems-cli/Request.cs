using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;

namespace GemsCLI
{
    public sealed class Request : List<ArgumentValue>
    {
        public List<ArgumentValue> this[string pNamed]
        {
            get { return (from value in this where value.isNamed && value.Name == pNamed select value).ToList(); }
        }

        /// <summary>
        /// A collection of Named parameter values.
        /// </summary>
        public List<ArgumentValue> Named
        {
            get { return (from value in this where value.isNamed select value).ToList(); }
        }

        /// <summary>
        /// A collection of Passed parameter values.
        /// </summary>
        public List<ArgumentValue> Passed
        {
            get { return (from value in this where !value.isNamed select value).ToList(); }
        }

        /// <summary>
        /// Initializes the class with a collection of values.
        /// </summary>
        /// <param name="pValues">Collection of argument values.</param>
        public Request(IEnumerable<ArgumentValue> pValues) : base(pValues)
        {
        }

        /// <summary>
        /// Checks if the request contains a Named parameter.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>True if at least one exists.</returns>
        public bool Contains(string pName)
        {
            return this.FirstOrDefault(pValue=>pValue.isNamed && pValue.Name == pName) != null;
        }

        /// <summary>
        /// Counts have many Named parameters there are.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>How many times this named parameter exists in the request.</returns>
        public int Count(string pName)
        {
            return Named.Count(pValue=>pValue.Name == pName);
        }
    }
}