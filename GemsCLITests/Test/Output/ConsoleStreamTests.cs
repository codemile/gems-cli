using System;
using System.IO;
using GemsCLI.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class ConsoleStreamTests
    {
        [TestMethod]
        public void Error()
        {
            using (StringWriter writer = new StringWriter())
            {
                Console.SetError(writer);
                ConsoleStream output = new ConsoleStream();
                output.Error("this is an error");

                Assert.AreEqual("this is an error",writer.ToString().Trim());
            }
        }

        [TestMethod]
        public void Standard()
        {
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                ConsoleStream output = new ConsoleStream();
                output.Standard("this is a standard message");

                Assert.AreEqual("this is a standard message", writer.ToString().Trim());
            }
        }
    }
}