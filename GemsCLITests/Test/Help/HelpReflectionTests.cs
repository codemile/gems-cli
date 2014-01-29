using GemsCLI.Exceptions;
using GemsCLI.Help;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Help
{
    [TestClass]
    public class HelpReflectionTests
    {
        [TestMethod]
        public void Get()
        {
            HelpReflection help = new HelpReflection(typeof(MockHelp));
            Assert.AreEqual("The filename to write.", help.Get("filename"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidArgumentException))]
        public void HelpReflection()
        {
            HelpReflection help = new HelpReflection(typeof(string));
        }
    }
}