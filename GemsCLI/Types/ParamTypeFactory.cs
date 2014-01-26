using GemsCLI.Exceptions;

namespace GemsCLI.Types
{
    public static class ParamTypeFactory
    {
        /// <summary>
        /// Initializes a parameter type object that handles converting
        /// a string to that given type.
        /// </summary>
        /// <param name="pType">The parameter type's name</param>
        /// <returns>A new parameter type object.</returns>
        /// <exception cref="SyntaxErrorException">If the parameter type is invalid</exception>
        public static iParamType Create(string pType)
        {
            if (string.IsNullOrWhiteSpace(pType))
            {
                throw new SyntaxErrorException("Parameter type can not be empty.");
            }

            switch (pType.Trim().ToLower())
            {
                case "string":
                    return new ParamString();
                case "int":
                    return new ParamInt();
            }

            throw new SyntaxErrorException("Parameter type {0} is not supported.", pType);
        }
    }
}