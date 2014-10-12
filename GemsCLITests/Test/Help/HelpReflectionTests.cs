using GemsCLI.Exceptions;
using GemsCLI.Helper;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Help
{
    [TestClass]
    public class HelpReflectionTests
    {
        [TestMethod]
        public void Get_0()
        {
            HelpReflection help = new HelpReflection(typeof(MockHelp));
            Assert.AreEqual("The filename to write.", help.Get("filename"));
        }

        [TestMethod]
        [ExpectedException(typeof (HelpException))]
        public void Get_1()
        {
            HelpReflection help = new HelpReflection(typeof(MockHelp));
            help.Get("mock");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidArgumentException))]
        public void HelpReflection()
        {
            HelpReflection help = new HelpReflection(typeof(string));
        }
    }
}