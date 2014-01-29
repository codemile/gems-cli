using GemsCLI;
using GemsCLI.Arguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test
{
    [TestClass]
    public class RequestTests
    {
        [TestMethod]
        public void Contains()
        {
            Argument[] args = {new ArgumentNamed(0,"width","string"), new ArgumentNamed(1,"height","string") };

            Request r = new Request(args);

            Assert.IsTrue(r.Contains("width"));
            Assert.IsTrue(r.Contains("height"));

            Assert.IsFalse(r.Contains("name"));
        }

        [TestMethod]
        public void Count()
        {
            Argument[] args =
            {
                new ArgumentNamed(0, "width", "string"), 
                new ArgumentNamed(0, "width", "string"), 
                new ArgumentNamed(1, "height", "string")
            };

            Request r = new Request(args);
            Assert.AreEqual(2,r.Count("width"));
            Assert.AreEqual(1,r.Count("height"));
            Assert.AreEqual(0,r.Count("depth"));
        }

        [TestMethod]
        public void Request()
        {
            Argument[] args = {};
            Request r = new Request(args);
        }
    }
}