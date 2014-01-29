namespace GemsCLI
{
    public class CliOptions
    {
        /// <summary>
        /// A generic style "cli -help -user=mathew"
        /// </summary>
        public static CliOptions BasicStyle = new CliOptions {Help = "help", EqualChar = "=", Prefix = "-"};

        /// <summary>
        /// Common style for Linux "mysql --help --user=mathew"
        /// </summary>
        public static CliOptions LinuxStyle = new CliOptions {Help = "help", EqualChar = "=", Prefix = "--"};

        /// <summary>
        /// Common style for Windows "dir /? /s /a:d"
        /// </summary>
        public static CliOptions WindowsStyle = new CliOptions {Help = "?", EqualChar = ":", Prefix = "/"};

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