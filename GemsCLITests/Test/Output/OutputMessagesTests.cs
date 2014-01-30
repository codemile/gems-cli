using System;
using System.IO;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Output;
using GemsCLI.Types;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class OutputMessagesTests
    {
        private static string getError(OutputMessages pMessages, Description pDescription, eERROR pError)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetError(sw);
                pMessages.Error(pDescription, pError);
                return sw.ToString().Trim();
            }
        }

        private static string getStandard(iOutputStream pOutput, string pStr)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                pOutput.Standard(pStr);
                return sw.ToString().Trim();
            }
        }

        [TestMethod]
        public void OutputMessages()
        {
            MockOutput mock = new MockOutput();
            OutputMessages output = new OutputMessages(CliOptions.WindowsStyle, mock);
        }

        [TestMethod]
        public void Unknown()
        {
        }

        [TestMethod]
        public void Error_0()
        {
            Description desc = new Description("width", "The rectangle width", eROLE.NAMED, new ParamString(),
                eSCOPE.REQUIRED,
                eMULTIPLICITY.ONCE);

            MockOutput mock = new MockOutput();
            OutputMessages messages = new OutputMessages(CliOptions.WindowsStyle, mock);

            mock.Clear();
            messages.Error(desc, eERROR.REQUIRED);
            CollectionAssert.AreEqual(new[]{"GemsCLI: option '/width' is required."}, mock.getLines());

            mock.Clear();
            messages.Error(desc, eERROR.DUPLICATE);
            CollectionAssert.AreEqual(new[]{"GemsCLI: option '/width' can only be used once."}, mock.getLines());

            mock.Clear();
            messages.Error(desc, eERROR.MISSING_VALUE);
            CollectionAssert.AreEqual(new[]{"GemsCLI: option '/width' is missing value."}, mock.getLines());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidArgumentException))]
        public void Error_1()
        {
            MockOutput mock = new MockOutput();
            OutputMessages output = new OutputMessages(CliOptions.WindowsStyle, mock);

            Description desc = new Description("width", "The rectangle width", eROLE.NAMED, new ParamString(),
                eSCOPE.REQUIRED,
                eMULTIPLICITY.ONCE);

            const eERROR unsupported = (eERROR)(-1);
            output.Error(desc, unsupported);
        }

    }
}