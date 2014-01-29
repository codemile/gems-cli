using System;
using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;

namespace GemsCLI
{
    public sealed class Request : List<Argument>
    {
        /// <summary>
        /// Indicates if the request contains valid arguments.
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// Selects all the arguments for a given type.
        /// </summary>
        /// <typeparam name="T">The argument class type.</typeparam>
        /// <returns>A collection of just those types.</returns>
        private IEnumerable<T> Select<T>() where T : Argument
        {
            return from attr in this where attr is T select attr as T;
        }

        /// <summary>
        /// Initializes the class with a collection of values.
        /// </summary>
        /// <param name="pValues">Collection of argument values.</param>
        /// <param name="pDescs">Collection of parameter descriptions.</param>
        public Request(IEnumerable<Argument> pValues, IEnumerable<Description> pDescs)
            : base(pValues)
        {
            Valid = true;

            IEnumerable<Description> descs = pDescs as Description[] ?? pDescs.ToArray();
            foreach (Argument arg in this)
            {
                arg.Attach(descs);
            }
        }

        /// <summary>
        /// Selects all the arguments that have a description attached.
        /// </summary>
        /// <returns>A collection of arguments with descriptions.</returns>
        private IEnumerable<Argument> Discribed()
        {
            return from attr in this where attr.Desc != null select attr;
        }

        /// <summary>
        /// Checks if the request contains a Named parameter.
        /// </summary>
        /// <param name="pName">The name of the Named parameter.</param>
        /// <returns>True if at least one exists.</returns>
        public bool Contains(string pName)
        {
            return Discribed().Any(pValue => pValue.Desc.Name == pName);
        }

        /// <summary>
        /// Counts how many Named parameters there are.
        /// </summary>
        /// <param name="pName">The name of the parameter.</param>
        /// <returns>How many times this named parameter exists in the request.</returns>
        public int Count(string pName)
        {
            return Discribed().Count(pValue => pValue.Desc.Name == pName);
        }

        /// <summary>
        /// Finds the first argument that matches the name.
        /// </summary>
        /// <param name="pName">The name of the argument.</param>
        /// <returns>The argument or null.</returns>
        public Argument First(string pName)
        {
            return
                Discribed().FirstOrDefault(pArg => string.Compare(pArg.Desc.Name, pName, StringComparison.OrdinalIgnoreCase) == 0);
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
        /// Selects all the named arguments.
        /// </summary>
        /// <returns>A collection of named arguments.</returns>
        public IEnumerable<ArgumentNamed> Named()
        {
            return Select<ArgumentNamed>();
        }

        /// <summary>
        /// Selects all the passed arguments.
        /// </summary>
        /// <returns>A collection of passed arguments.</returns>
        public IEnumerable<ArgumentPassed> Passed()
        {
            return Select<ArgumentPassed>();
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
            return (from arg in Discribed()
                    where string.Compare(arg.Desc.Name, pName, StringComparison.OrdinalIgnoreCase) == 0
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
            return (from arg in Discribed()
                    where string.Compare(arg.Desc.Name, pName, StringComparison.OrdinalIgnoreCase) == 0
                    select (T)Convert.ChangeType(arg.Value, typeof (T))).ToList();
        }
    }
}