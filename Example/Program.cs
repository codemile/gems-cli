using System;
using System.Diagnostics;
using System.Reflection;
using GemsCLI.Arguments;

namespace Example
{
    internal static class Program
    {
        /// <summary>
        /// Creates the parser.
        /// </summary>
        private static Parser Create()
        {
            Parser parser = new Parser();
            parser.Param("address", "The IP address of the MySQL server.", true, false, "localhost");
            parser.Param("database", "The database name to use.", true, true);
            parser.Param("username", "The username to use in the database connection.", true, true);
            parser.Param("password", "The password to use in the database connection.", true, true);
            parser.Param("output", "The output folder to write files.", true, true);
            parser.Param("namespace", "The C# namespace for classes.", true, true);
            parser.Param("skip", "Comma delimited list of table prefixes to ignore.", true, false);
            parser.Param("tail", "The text to add to the end of the output file's name.", true, false, "Entity");
            parser.Param("merge",
                "To give multiple entities a common base class. Join table names with a + and assign to a base classname using =. You can define more then one merge rule by using a comma delimiter.",
                true, false, "Entity");
            parser.Param("help", "Displays this help message.", false, false);

            return parser;
        }

        /// <summary>
        /// The main entry point for the example.
        /// </summary>
        /// <param name="pArgs"></param>
        private static void Main(string[] pArgs)
        {
            WriteInfo();
            Parser args = Create();
            args.Parse(pArgs);
            if (args.Has("help"))
            {
                args.ShowHelp("Example");
                return;
            }
            args.Validate();
        }

        /// <summary>
        /// Displays program greeting.
        /// </summary>
        private static void WriteInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            Console.WriteLine("Example Version {0}", version);
            Console.WriteLine("MIT License (MIT), ThinkingMedia.");
            Console.WriteLine("Author: Mathew Foscarini, mathew@thinkingmedia.ca");
            Console.WriteLine("");
        }
    }
}