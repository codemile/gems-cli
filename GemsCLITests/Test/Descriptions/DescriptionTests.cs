using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Properties;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Descriptions
{
    [TestClass]
    public class DescriptionTests
    {
        [TestMethod]
        public void Description_0()
        {
            try
            {
                Description d = new Description(null, "help", eROLE.NAMED, new MockParamType(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE);
                Assert.Fail();
            }
            catch (SyntaxErrorException e)
            {
                Assert.AreEqual(Errors.DescriptionName, e.Message);
            }
        }

        [TestMethod]
        public void Description_1()
        {
            try
            {
                Description d = new Description("filename", null, eROLE.NAMED, new MockParamType(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE);
                Assert.Fail();
            }
            catch (SyntaxErrorException e)
            {
                Assert.AreEqual(Errors.DescriptionHelp, e.Message);
            }
        }

        [TestMethod]
        public void Description_2()
        {
            try
            {
                Description d = new Description("filename", "help", eROLE.NAMED, null, eSCOPE.REQUIRED,
                    eMULTIPLICITY.MULTIPLE);
                Assert.Fail();
            }
            catch (SyntaxErrorException e)
            {
                Assert.AreEqual(Errors.DescriptionSingle, e.Message);
            }
        }

        [TestMethod]
        public void Description_3()
        {
            try
            {
                Description d = new Description("filename", "help", eROLE.PASSED, null, eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE);
                Assert.Fail();
            }
            catch (SyntaxErrorException e)
            {
                Assert.AreEqual(Errors.DescriptionTypeRequired, e.Message);
            }
        }

        [TestMethod]
        public void Description_4()
        {
            try
            {
                Description d = new Description("123", "help", eROLE.PASSED, new MockParamType(), eSCOPE.REQUIRED,
                    eMULTIPLICITY.ONCE);
                Assert.Fail();
            }
            catch (SyntaxErrorException e)
            {
                Assert.AreEqual(Errors.DescriptionInvalidName, e.Message);
            }
        }
    }
}