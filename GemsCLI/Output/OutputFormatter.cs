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
        /// Uses the assembly details to find the name of the current app.
        /// </summary>
        /// <returns>The current application's name.</returns>
        public static string AppName()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
            return info.ProductName;
        }

        /// <summary>
        /// Gives the name of the executable file for the current process.
        /// </summary>
        /// <returns>The filename without extension.</returns>
        public static string ExecutableName()
        {
            string full = Assembly.GetEntryAssembly().Location;
            return Path.GetFileNameWithoutExtension(full);
        }

        /// <summary>
        /// Formats a message based upon a parameter description.
        /// </summary>
        /// <param name="pRole">The parameter's role.</param>
        /// <param name="pPrefx">Prefix used for named parameters.</param>
        /// <param name="pName">The name of the parameter</param>
        public static string WriteRequired(eROLE pRole, string pPrefx, string pName)
        {
            string app = AppName();
            return pRole == eROLE.NAMED
                ? string.Format("{0}: option '{1}{2}' is required.", app, pPrefx, pName)
                : string.Format("{0}: value <{1}> is required.", app, pName ?? "no name");
        }
    }
}