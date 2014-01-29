using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Arguments
{
    [TestClass]
    public class ArgumentPassedTests
    {
        [TestMethod]
        public void ArgumentPassed_0()
        {
            ArgumentPassed arg = new ArgumentPassed(0,"document.txt");
            Assert.AreEqual(0, arg.Order);

            arg.Order = 99;
            Assert.AreEqual(99, arg.Order);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException), "Null value not allowed.")]
        public void ArgumentPassed_1()
        {
            ArgumentPassed arg = new ArgumentPassed(0, null);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException), "Empty value not allowed.")]
        public void ArgumentPassed_2()
        {
            ArgumentPassed arg = new ArgumentPassed(0, "");
        }

        [TestMethod]
        public void Attach()
        {
            Description desc = new Description("filename", "the filename", eROLE.PASSED, new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE);
            ArgumentPassed arg = new ArgumentPassed(0, "document.txt");
            arg.Attach(new[]{desc});

            Assert.IsNotNull(arg.Desc);
        }
    }
}