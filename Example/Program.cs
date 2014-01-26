using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Example.Properties;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Help;

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

            List<Description> descs = DescriptionFactory.Create(
                ParserOptions.WindowsStyle, new HelpResource(Help.ResourceManager),
                "/echo [/mode:string#] /address:string /database:string /username:string [/password:string] filename [output:string]"
                );

            Parser parser = ParserFactory.Create(pArgs, descs);
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