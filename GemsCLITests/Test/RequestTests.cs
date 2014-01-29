using System.Collections.Generic;
using GemsCLI;
using GemsCLI.Arguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test
{
    [TestClass]
    public class RequestTests
    {
        private Argument[] _arguments;
        private Request _r;

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
            _arguments = new Argument[]
                         {
                             new ArgumentNamed(0, "width", "10"),
                             new ArgumentNamed(1, "width", "20"),
                             new ArgumentNamed(2, "height", "30"),
                             new ArgumentPassed(3, "filename", "document.txt"),
                             new ArgumentPassed(4, "command", "start")
                         };
            ((ArgumentPassed)_arguments[4]).Order = 1;
            _r = new Request(_arguments);
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