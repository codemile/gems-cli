using GemsCLI.Exceptions;
using GemsCLI.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Help
{
    [TestClass]
    public class HelpDictionaryTests
    {
        [TestMethod]
        public void GetTest_0()
        {
            HelpDictionary help = new HelpDictionary
                                  {
                                      {"WIDTH", Properties.Help.Width},
                                      {"HEIGHT", Properties.Help.Height}
                                  };

            Assert.AreEqual(Properties.Help.Width, help.Get("width"));
            Assert.AreEqual(Properties.Help.Height, help.Get("Height"));
        }

        [TestMethod]
        [ExpectedException(typeof (HelpException))]
        public void GetTest_1()
        {
            HelpDictionary help = new HelpDictionary
                                  {
                                      {"WIDTH", ""},
                                      {"HEIGHT", Properties.Help.Height}
                                  };
            help.Get("width");
        }
    }
}