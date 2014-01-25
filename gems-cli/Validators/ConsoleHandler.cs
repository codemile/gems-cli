using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GemsCLI.Arguments;
using GemsCLI.Enums;

namespace GemsCLI.Validators
{
    public class ConsoleHandler : iParameterError
    {
        private readonly ParserOptions _options;
        private readonly string _app;

        /// <summary>
        /// Initializes this class
        /// </summary>
        public ConsoleHandler(ParserOptions pOptions)
        {
            _options = pOptions;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            _app = fvi.ProductName;
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

        private void Write(Description pDesc)
        {
            if (pDesc.isNamed)
            {
                Console.Error.WriteLine("{0}: option '{1}{2}' is required.", _app, _options.Prefix, pDesc.Name);
                return;
            }
            Console.Error.WriteLine("{0}: value <{1}> is required.", _app, pDesc.Name ?? "no name");
        }
    }
}
