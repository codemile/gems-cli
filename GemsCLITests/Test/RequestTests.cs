using System.Collections.Generic;
using GemsCLI;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test
{
    [TestClass]
    public class RequestTests
    {
        private Argument[] _arguments;
        private Request _r;

        [TestMethod]
        public void Request_0()
        {
            Description desc = new Description("filename", "the filename", eROLE.PASSED, new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE);
            ArgumentPassed passed = new ArgumentPassed(0,"document.txt");

            Request r = new Request(new[]{passed},new[]{desc});

            // ensure description is attached to argument
            Assert.IsNotNull(passed.Desc);
        }

        [TestMethod]
        public void Contains()
        {
            Assert.IsTrue(_r.Contains("width"));
            Assert.IsTrue(_r.Contains("height"));

            Assert.IsFalse(_r.Contains("name"));
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(2, _r.Count("width"));
            Assert.AreEqual(1, _r.Count("height"));
            Assert.AreEqual(0, _r.Count("depth"));
        }

        [TestMethod]
        public void First()
        {
            Assert.AreEqual("10", _r.First("width").Value);
        }

        [TestMethod]
        public void Get()
        {
            Assert.AreEqual(10, _r.Get<int>("width"));
            Assert.AreEqual(30, _r.Get<long>("height"));
            Assert.AreEqual(null, _r.Get<string>("mock"));
        }

        [TestInitialize]
        public void Init()
        {
            Description[] descs =
            {
                new Description("width","The width",eROLE.NAMED, new ParamInt(),eSCOPE.REQUIRED, eMULTIPLICITY.MULTIPLE ), 
                new Description("height","The height",eROLE.NAMED, new ParamInt(),eSCOPE.REQUIRED, eMULTIPLICITY.ONCE ), 
                new Description("filename","The filename",eROLE.PASSED, new ParamString(),eSCOPE.OPTIONAL, eMULTIPLICITY.ONCE ), 
                new Description("mode","The mode",eROLE.PASSED, new ParamString(),eSCOPE.OPTIONAL, eMULTIPLICITY.ONCE ), 
            };

            _arguments = new Argument[]
                         {
                             new ArgumentNamed(0, "width", "10"),
                             new ArgumentNamed(1, "width", "20"),
                             new ArgumentNamed(2, "height", "30"),
                             new ArgumentPassed(3, "document.txt"),
                             new ArgumentPassed(4, "start")
                         };
            ((ArgumentPassed)_arguments[4]).Order = 1;
            _r = new Request(_arguments, descs);
        }

        [TestMethod]
        public void ToArray()
        {
            int[] widths = _r.ToArray<int>("width");
            int[] heights = _r.ToArray<int>("height");

            Assert.IsNotNull(widths);
            Assert.AreEqual(2,widths.Length);
            CollectionAssert.AreEqual(new []{10,20},widths);

            Assert.IsNotNull(heights);
            Assert.AreEqual(1, heights.Length);
            CollectionAssert.AreEqual(new[] { 30 }, heights);
        }

        [TestMethod]
        public void ToList()
        {
            List<int> widths = _r.ToList<int>("width");
            List<int> heights = _r.ToList<int>("height");

            Assert.IsNotNull(widths);
            Assert.AreEqual(2, widths.Count);
            CollectionAssert.AreEqual(new List<int> { 10, 20 }, widths);

            Assert.IsNotNull(heights);
            Assert.AreEqual(1, heights.Count);
            CollectionAssert.AreEqual(new List<int> { 30 }, heights);
        }
    }
}