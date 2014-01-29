using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;

namespace GemsCLI
{
    public sealed class Request : List<Argument>
    {
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

        /// <summary>
        /// Finds the first argument that matches the name.
        /// </summary>
        /// <param name="pName">The name of the argument.</param>
        /// <returns>The argument or null.</returns>
        public Argument First(string pName)
        {
            return this.FirstOrDefault(pArg=>string.Compare(pArg.Name, pName, StringComparison.OrdinalIgnoreCase) == 0);
        }

        /// <summary>
        /// Attempts to convert the argument string value to a different type.
        /// </summary>
        /// <typeparam name="T">The class type to convert too.</typeparam>
        /// <param name="pName">Name of the argument.</param>
        /// <returns>The converted type.</returns>
        public T Get<T>(string pName)
        {
            Argument arg = First(pName);
            if (arg == null || arg.Value == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(arg.Value, typeof (T));
        }

        /// <summary>
        /// Finds all the arguments on the command line for a given name, and converts each
        /// into the given type returning a collection of that type.
        /// </summary>
        /// <typeparam name="T">The class type to convert too.</typeparam>
        /// <param name="pName">name of the argument</param>
        /// <returns>An array of that type.</returns>
        public T[] ToArray<T>(string pName)
        {
            return (from arg in this
                    where string.Compare(arg.Name, pName, StringComparison.OrdinalIgnoreCase) == 0
                    select (T)Convert.ChangeType(arg.Value, typeof (T))).ToArray();
        }

        /// <summary>
        /// Finds all the arguments on the command line for a given name, and converts each
        /// into the given type returning a collection of that type.
        /// </summary>
        /// <typeparam name="T">The class type to convert too.</typeparam>
        /// <param name="pName">name of the argument</param>
        /// <returns>A list of that type.</returns>
        public List<T> ToList<T>(string pName)
        {
            return (from arg in this
                    where string.Compare(arg.Name, pName, StringComparison.OrdinalIgnoreCase) == 0
                    select (T)Convert.ChangeType(arg.Value, typeof (T))).ToList();
        }
    }
}