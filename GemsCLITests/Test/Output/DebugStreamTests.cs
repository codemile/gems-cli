using System.Diagnostics;
using System.IO;
using GemsCLI.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class DebugStreamTests
    {
        [TestMethod]
        public void Error()
        {
            using (StringWriter writer = new StringWriter())
            {
                using (TextWriterTraceListener listener = new TextWriterTraceListener(writer))
                {
                    Debug.Listeners.Add(listener);
                    DebugStream output = new DebugStream();
                    output.Error("this is an error");
                }
                Assert.AreEqual("ERROR:this is an error", writer.ToString().Trim());
            }
        }

        [TestMethod]
        public void Standard()
        {
            using (StringWriter writer = new StringWriter())
            {
                using (TextWriterTraceListener listener = new TextWriterTraceListener(writer))
                {
                    Debug.Listeners.Add(listener);
                    DebugStream output = new DebugStream();
                    output.Standard("this is a standard message");
                }
                Assert.AreEqual("this is a standard message", writer.ToString().Trim());
            }
        }
    }
}