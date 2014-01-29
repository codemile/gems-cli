using GemsCLI.Arguments;
using GemsCLI.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Arguments
{
    [TestClass]
    public class ArgumentNamedTests
    {
        [TestMethod]
        public void ArgumentNamed_0()
        {
            ArgumentNamed arg = new ArgumentNamed(2, "test", "wow");

            Assert.AreEqual(2, arg.Index);
            Assert.AreEqual("test", arg.Name);
            Assert.AreEqual("wow", arg.ValueType);

            arg = new ArgumentNamed(6, "test", null);

            Assert.AreEqual(6, arg.Index);
            Assert.AreEqual("test", arg.Name);
            Assert.IsNull(arg.ValueType);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException))]
        public void ArgumentNamed_1()
        {
            ArgumentNamed arg = new ArgumentNamed(0, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException))]
        public void ArgumentNamed_2()
        {
            ArgumentNamed arg = new ArgumentNamed(0, "", null);
        }
    }
}