using System;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Arguments
{
    [TestClass]
    public class ArgumentNamedTests
    {
        [TestMethod]
        public void ArgumentNamed_0()
        {
            ArgumentNamed arg = new ArgumentNamed(2, "test", "wow");

            Assert.AreEqual(2, arg.Index);
            Assert.AreEqual("test", arg.Name);
            Assert.AreEqual("wow", arg.Value);

            arg = new ArgumentNamed(6, "test", null);

            Assert.AreEqual(6, arg.Index);
            Assert.AreEqual("test", arg.Name);
            Assert.IsNull(arg.Value);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException))]
        public void ArgumentNamed_1()
        {
            ArgumentNamed arg = new ArgumentNamed(0, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException))]
        public void ArgumentNamed_2()
        {
            ArgumentNamed arg = new ArgumentNamed(0, "", null);
        }

        [TestMethod]
        public void Attach()
        {
            Description desc = new Description("filename", "the filename", eROLE.NAMED, new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE);
            ArgumentNamed arg = new ArgumentNamed(0, "filename", "document.txt");
            arg.Attach(new[] { desc });

            Assert.IsNotNull(arg.Desc);
        }
    }
}