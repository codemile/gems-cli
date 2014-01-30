using GemsCLI.Output;

namespace GemsCLITests.Mock
{
    public class MockOutputFactory : iOutputFactory
    {
        /// <summary>
        /// Creates an output handler object.
        /// </summary>
        /// <returns>The new object.</returns>
        public iOutputStream Create()
        {
            return new MockOutput();
        }
    }
}