using GemsCLI.Enums;
using GemsCLI.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class OutputFormatterTests
    {
        [TestMethod]
        public void AppName()
        {
            Assert.AreEqual("GemsCLI", OutputFormatter.AppName());
        }

        [TestMethod]
        public void ExecutableNameTest()
        {
            Assert.AreEqual("GemsCLI", OutputFormatter.ExecutableName());
        }

        [TestMethod]
        public void WriteDuplicateTest()
        {
            Assert.AreEqual(
                "GemsCLI: option '/width' can only be used once.",
                OutputFormatter.WriteDuplicate(eROLE.NAMED, "/", "width"));
        }

        [TestMethod]
        public void WriteMissingValueTest()
        {
            Assert.AreEqual(
                "GemsCLI: option '/width' is missing value.",
                OutputFormatter.WriteMissingValue(eROLE.NAMED, "/", "width"));
        }

        [TestMethod]
        public void WriteRequiredTest()
        {
            Assert.AreEqual(
                "GemsCLI: option '/width' is required.",
                OutputFormatter.WriteRequired(eROLE.NAMED, "/", "width"));
        }

        [TestMethod]
        public void WriteUnknownTest()
        {
            Assert.AreEqual(
                "GemsCLI: value 'width' is not a recognized option.",
                OutputFormatter.WriteUnknown("width"));
        }
    }
}