using GemsCLI.Attributes;

namespace GemsCLITests.Mock
{
    public class MockHelp
    {
        [CliHelp("The filename to write.")]
        public string FileName { get; set; }
    }
}