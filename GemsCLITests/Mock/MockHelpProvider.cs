using GemsCLI.Helper;

namespace GemsCLITests.Mock
{
    public class MockHelpProvider : iHelpProvider
    {
        /// <summary>
        /// Gets the help message for a parameter by it's name.
        /// </summary>
        /// <param name="pName">Name of the parameter.</param>
        /// <returns>A help message.</returns>
        public string Get(string pName)
        {
            return "This is mocked help message.";
        }
    }
}