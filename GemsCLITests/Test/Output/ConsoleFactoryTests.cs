using GemsCLI;
using GemsCLI.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class ConsoleFactoryTests
    {
        [TestMethod]
        public void Create()
        {
            ConsoleFactory factory = new ConsoleFactory();
            iOutputStream stream = factory.Create();

            Assert.IsNotNull(stream);

            stream.Standard("test");
            stream.Error("test");
        }
    }
}