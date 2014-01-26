using System.Diagnostics;
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