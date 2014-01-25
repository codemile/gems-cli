namespace GemsCLI
{
    public class ParserOptions
    {
        /// <summary>
        /// A generic style "cli -help -user=mathew"
        /// </summary>
        public static ParserOptions BasicStyle = new ParserOptions {Help = "help", EqualChar = "=", Prefix = "-"};

        /// <summary>
        /// Common style for Linux "mysql --help --user=mathew"
        /// </summary>
        public static ParserOptions LinuxStyle = new ParserOptions {Help = "help", EqualChar = "=", Prefix = "--"};

        /// <summary>
        /// Common style for Windows "dir /? /s /a:d"
        /// </summary>
        public static ParserOptions WindowsStyle = new ParserOptions {Help = "?", EqualChar = ":", Prefix = "/"};

        /// <summary>
        /// The character used to assign a value to a parameter.
        /// Default: "="
        /// </summary>
        public string EqualChar { get; set; }

        /// <summary>
        /// The term used to trigger help.
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// What characters prefix to indicate a parameter.
        /// Example: example.exe --option=0
        /// The string "--" is the prefix of "option"
        /// </summary>
        public string Prefix { get; set; }
    }
}