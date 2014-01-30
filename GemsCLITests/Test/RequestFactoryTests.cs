using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Output;
using GemsCLI.Types;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test
{
    [TestClass]
    public class RequestFactoryTests
    {
        [TestMethod]
        public void CreateTest_0()
        {
        }

        [TestMethod]
        public void CreateTest_1()
        {
            Description[] descs =
            {
                new Description("width", "The width of the rectangle", eROLE.NAMED, new ParamInt(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE),
                new Description("height", "The height of the rectangle", eROLE.NAMED, new ParamInt(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE),
                new Description("filename", "The input file", eROLE.PASSED, new ParamString(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE)
            };

            Request request = RequestFactory.Create(CliOptions.WindowsStyle, new[] { "/width:100", "/height:200", "document.txt" }, descs, new MockOutputFactory());
            Assert.IsNotNull(request);

            int width = request.Get<int>("width");
            int height = request.Get<int>("height");
            string filename = request.Get<string>("filename");

            Assert.AreEqual(100, width);
            Assert.AreEqual(200, height);
            Assert.AreEqual("document.txt", filename);
        }
    }
}