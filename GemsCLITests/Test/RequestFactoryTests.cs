using System.Collections.Generic;
using System.Linq;
using GemsCLI;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Types;
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
                new Description("width","The width of the rectangle", eROLE.NAMED, new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE), 
                new Description("height","The height of the rectangle", eROLE.NAMED, new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE)
            };

            Request request = RequestFactory.Create(new[] {"/width:100","/height:200"}, descs);
            Assert.IsNotNull(request);

            List<Argument> widths = request["width"];
            List<Argument> heights = request["height"];

            Assert.AreEqual(1, widths.Count);
            Assert.AreEqual(1, heights.Count);

            Assert.AreEqual("100", widths[0].Value);
            Assert.AreEqual("200", heights[0].Value);
        }
    }
}