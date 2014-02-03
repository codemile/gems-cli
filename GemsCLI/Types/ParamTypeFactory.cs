using GemsCLI.Exceptions;
using GemsCLI.Properties;

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
                throw new SyntaxErrorException(Errors.ParamTypeFactoryNull);
            }

            switch (pType.Trim().ToLower())
            {
                case "string":
                    return new ParamString();
                case "int":
                    return new ParamInt();
                case "boolean":
                    return new ParamBool();
            }

            throw new SyntaxErrorException(Errors.ParamTypeFactoryUnknown, pType);
        }
    }
}