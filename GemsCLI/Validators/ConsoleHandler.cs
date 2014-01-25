using System;
using System.Diagnostics;
using System.Reflection;
using GemsCLI.Descriptions;
using GemsCLI.Enums;

namespace GemsCLI.Validators
{
    public class ConsoleHandler : iParameterError
    {
        private readonly string _app;
        private readonly ParserOptions _options;

        private void Write(Description pDesc)
        {
            if (pDesc.isNamed)
            {
                Console.Error.WriteLine("{0}: option '{1}{2}' is required.", _app, _options.Prefix, pDesc.Name);
                return;
            }
            Console.Error.WriteLine("{0}: value <{1}> is required.", _app, pDesc.Name ?? "no name");
        }

        /// <summary>
        /// Initializes this class
        /// </summary>
        public ConsoleHandler(ParserOptions pOptions)
        {
            _options = pOptions;

            Assembly assembly = Assembly.GetEntryAssembly();
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
            _app = info.ProductName;
        }

        /// <summary>
        /// Called when a validation fails on the parameters.
        /// </summary>
        /// <param name="pDesc">The description of the failed parameter.</param>
        /// <param name="pError">The type of error.</param>
        public void Error(Description pDesc, eERROR pError)
        {
            switch (pError)
            {
                case eERROR.REQUIRED:
                    Write(pDesc);
                    break;
            }
        }
    }
}