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

            int width = request.Get<int>("width");
            int height = request.Get<int>("height");

            Assert.AreEqual(100, width);
            Assert.AreEqual(200, height);
        }
    }
}