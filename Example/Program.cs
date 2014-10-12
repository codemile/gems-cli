using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Example.Properties;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Helper;
using GemsCLI.Output;

namespace Example
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the example.
        /// </summary>
        /// <param name="pArgs">The arguments from the command line.</param>
        private static void Main(string[] pArgs)
        {
            WriteGreeting();

            CliOptions options = CliOptions.WindowsStyle;

            List<Description> descs = DescriptionFactory.Create(
                options, new HelpResource(Help.ResourceManager),
                "/echo [/mode:string#] /address:string /database:string /username:string [/password:string] filename [output:string]"
                );

            ConsoleFactory consoleFactory = new ConsoleFactory();

            if (pArgs.Length == 0)
            {
                OutputHelp outputHelp = new OutputHelp(options, consoleFactory.Create());
                outputHelp.Show(descs);
                return;
            }

            Request request = RequestFactory.Create(options, pArgs, descs, consoleFactory);
        }

        /// <summary>
        /// Displays program greeting.
        /// </summary>
        private static void WriteGreeting()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            Console.WriteLine(Resource.Greeting_Version, version);
            Console.WriteLine(Resource.Greeting_Company);
            Console.WriteLine(Resource.Greeting_Contact);
            Console.WriteLine("");
        }
    }
}