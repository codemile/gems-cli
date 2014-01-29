using GemsCLI.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Help
{
    [TestClass]
    public class HelpDictionaryTests
    {
        [TestMethod]
        public void GetTest()
        {
            HelpDictionary help = new HelpDictionary
                                  {
                                      {"WIDTH", Properties.Help.Width},
                                      {"HEIGHT", Properties.Help.Height}
                                  };

            Assert.AreEqual(Properties.Help.Width, help.Get("width"));
            Assert.AreEqual(Properties.Help.Height, help.Get("Height"));
        }
    }
}