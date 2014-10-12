using GemsCLI.Exceptions;
using GemsCLI.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Help
{
    [TestClass]
    public class HelpResourceTests
    {
        [TestMethod]
        public void HelpResource()
        {
            HelpResource help = new HelpResource(Properties.Help.ResourceManager);
        }

        [TestMethod]
        public void Get_0()
        {
            HelpResource help = new HelpResource(Properties.Help.ResourceManager);
            Assert.AreEqual(Properties.Help.Width, help.Get("width"));
            Assert.AreEqual(Properties.Help.Height, help.Get("height"));
        }

        [TestMethod]
        [ExpectedException(typeof(HelpException))]
        public void Get_1()
        {
            HelpResource help = new HelpResource(Properties.Help.ResourceManager);
            help.Get("mock");
        }
    }
}