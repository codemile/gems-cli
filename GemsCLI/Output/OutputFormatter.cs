using System.Diagnostics;
using System.IO;
using System.Reflection;
using GemsCLI.Enums;

namespace GemsCLI.Output
{
    /// <summary>
    /// Performs formatting of common output messages.
    /// </summary>
    public static class OutputFormatter
    {
        /// <summary>
        /// Finds the current assembly that best represents the executable.
        /// </summary>
        /// <returns>An assembly.</returns>
        private static Assembly getAssembly()
        {
            return Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Formats an error message.
        /// </summary>
        /// <param name="pRole">Parameter role</param>
        /// <param name="pPrefix">Parameter prefix</param>
        /// <param name="pName">Parameter name</param>
        /// <param name="pError">Error message</param>
        /// <returns>The formatted string</returns>
        private static string getError(eROLE pRole, string pPrefix, string pName, string pError)
        {
            string app = AppName();
            return pRole == eROLE.NAMED
                ? string.Format("{0}: option '{1}{2}' {3}.", app, pPrefix, pName, pError)
                : string.Format("{0}: value <{1}> {2}.", app, pName, pError);
        }

        /// <summary>
        /// Uses the assembly details to find the name of the current app.
        /// </summary>
        /// <returns>The current application's name.</returns>
        public static string AppName()
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(getAssembly().Location);
            return info.ProductName;
        }

        /// <summary>
        /// Gives the name of the executable file for the current process.
        /// </summary>
        /// <returns>The filename without extension.</returns>
        public static string ExecutableName()
        {
            string full = getAssembly().Location;
            return Path.GetFileNameWithoutExtension(full);
        }

        /// <summary>
        /// Formats a message based upon a parameter description.
        /// </summary>
        /// <param name="pRole">The parameter's role.</param>
        /// <param name="pPrefix">Prefix used for named parameters.</param>
        /// <param name="pName">The name of the parameter</param>
        public static string WriteDuplicate(eROLE pRole, string pPrefix, string pName)
        {
            return getError(pRole, pPrefix, pName, "can only be used once");
        }

        /// <summary>
        /// Formats a message based upon a parameter description.
        /// </summary>
        /// <param name="pRole">The parameter's role.</param>
        /// <param name="pPrefix">Prefix used for named parameters.</param>
        /// <param name="pName">The name of the parameter</param>
        public static string WriteMissingValue(eROLE pRole, string pPrefix, string pName)
        {
            return getError(pRole, pPrefix, pName, "is missing value");
        }

        /// <summary>
        /// Formats a message based upon a parameter description.
        /// </summary>
        /// <param name="pRole">The parameter's role.</param>
        /// <param name="pPrefix">Prefix used for named parameters.</param>
        /// <param name="pName">The name of the parameter</param>
        public static string WriteRequired(eROLE pRole, string pPrefix, string pName)
        {
            return getError(pRole, pPrefix, pName, "is required");
        }

        /// <summary>
        /// Formats a message based upon a parameter description.
        /// </summary>
        /// <param name="pRole">The parameter's role.</param>
        /// <param name="pPrefix">Prefix used for named parameters.</param>
        /// <param name="pName">The name of the parameter</param>
        public static string WriteUnknown(eROLE pRole, string pPrefix, string pName)
        {
            return getError(pRole, pPrefix, pName, "is not supported");
        }
    }
}