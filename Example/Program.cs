using System;
using System.Diagnostics;
using System.Reflection;
using Example.Properties;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Types;
using Help = Example.Properties.Help;

namespace Example
{
    internal static class Program
    {
        /// <summary>
        /// To read the arguments on the command line. An Arguments
        /// collection must be created. This describes to the parser
        /// when arguments are required, and the validation rules
        /// for those arguments.
        /// </summary>
        private static DescriptionList Create()
        {
            /**
             * Uses a resource file to define the help messages. Alternatively
             * use the Arguments class and manually provide help messages.
             */
            HelpResource help = new HelpResource(Help.ResourceManager, new DescriptionList(), false);

            /**
             * How to define an IP address.
             */
            help.AddType("address", new ParamIP("localhost"), eSCOPE.REQUIRED);

            /**
             * A String value.
             */
            help.AddType("database", new ParamString(), eSCOPE.REQUIRED);

            /**
             * Optional values.
             */
            help.AddString("username");
            help.AddString("password");

            /**
             * Integer range example.
             */
            help.AddInt("limit", 0, 10);

            return help.DescriptionList;
        }

        /// <summary>
        /// The main entry point for the example.
        /// </summary>
        /// <param name="pArgs">The arguments from the command line.</param>
        private static void Main(string[] pArgs)
        {
            WriteGreeting();

            DescriptionList descs = Create();
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