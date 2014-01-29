using System;
using System.IO;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Output;
using GemsCLI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class ConsoleOutputTests
    {
        private static string getError(iOutputHandler pOutput, Description pDescription, eERROR pError)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetError(sw);
                pOutput.Error(pDescription, pError);
                return sw.ToString().Trim();
            }
        }

        private static string getStandard(iOutputHandler pOutput, string pStr)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                pOutput.WriteLine(pStr);
                return sw.ToString().Trim();
            }
        }

        [TestMethod]
        public void ConsoleOutput()
        {
            ConsoleOutput o = new ConsoleOutput(CliOptions.WindowsStyle);
        }

        [TestMethod]
        public void Error_0()
        {
            ConsoleOutput output = new ConsoleOutput(CliOptions.WindowsStyle);
            Description desc = new Description("width", "The rectangle width", eROLE.NAMED, new ParamString(),
                eSCOPE.REQUIRED,
                eMULTIPLICITY.ONCE);

            Assert.AreEqual("GemsCLI: option '/width' is required.", getError(output, desc, eERROR.REQUIRED));
            Assert.AreEqual("GemsCLI: option '/width' can only be used once.", getError(output, desc, eERROR.DUPLICATE));
            Assert.AreEqual("GemsCLI: option '/width' is missing value.", getError(output, desc, eERROR.MISSING_VALUE));
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidArgumentException))]
        public void Error_1()
        {
            ConsoleOutput output = new ConsoleOutput(CliOptions.WindowsStyle);
            Description desc = new Description("width", "The rectangle width", eROLE.NAMED, new ParamString(),
                eSCOPE.REQUIRED,
                eMULTIPLICITY.ONCE);

            const eERROR unsupported = (eERROR)(-1);
            output.Error(desc, unsupported);
        }

        [TestMethod]
        public void WriteLine()
        {
            ConsoleOutput output = new ConsoleOutput(CliOptions.WindowsStyle);
            Assert.AreEqual("Hello World!", getStandard(output, "Hello World!"));
        }
    }
}