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
    }
}