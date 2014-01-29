using GemsCLI.Attributes;
using GemsCLI.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Attributes
{
    [TestClass()]
    public class CliNameTests
    {
        [TestMethod()]
        public void CliName()
        {
            CliName name = new CliName();
            Assert.AreEqual(eROLE.NAMED, name.Role);
            Assert.IsNull(name.Name);

            name = new CliName(eROLE.PASSED);
            Assert.AreEqual(eROLE.PASSED, name.Role);
            Assert.IsNull(name.Name);

            name = new CliName(eROLE.PASSED,"width");
            Assert.AreEqual(eROLE.PASSED, name.Role);
            Assert.AreEqual("width", name.Name);
        }
    }
}
