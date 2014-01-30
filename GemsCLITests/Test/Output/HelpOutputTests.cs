using System.Collections.Generic;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Output;
using GemsCLI.Types;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Output
{
    [TestClass]
    public class HelpOutputTests
    {
        [TestMethod]
        public void HelpOutput()
        {
            OutputHelp outputHelp = new OutputHelp(CliOptions.WindowsStyle, new MockOutput(), true);
        }

        [TestMethod]
        public void Show_0()
        {
            MockOutput output = new MockOutput();
            OutputHelp outputHelp = new OutputHelp(CliOptions.WindowsStyle, output, true);
            List<Description> descs = new List<Description>
                                      {
                                          new Description("width", "The width of the rectangle.", eROLE.NAMED,
                                              new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE),
                                          new Description("filename", "The input file.", eROLE.PASSED, new ParamString(),
                                              eSCOPE.OPTIONAL, eMULTIPLICITY.ONCE)
                                      };
            outputHelp.Show(descs);

            string[] lines = output.getLines();

            CollectionAssert.AreEqual(
                new[]
                {
                    "Usage: GemsCLI /width [filename]",
                    "Where options include:",
                    "/width The width of the rectangle.",
                    "filename* The input file.",
                    "* shows optional parameters."
                },
                lines);
        }

        [TestMethod]
        public void Show_1()
        {
            MockOutput output = new MockOutput();
            OutputHelp outputHelp = new OutputHelp(CliOptions.WindowsStyle, output);
            List<Description> descs = new List<Description>
                                      {
                                          new Description("width", "The width of the rectangle.", eROLE.NAMED,
                                              new ParamString(), eSCOPE.REQUIRED, eMULTIPLICITY.ONCE),
                                          new Description("filename", "The input file.", eROLE.PASSED, new ParamString(),
                                              eSCOPE.OPTIONAL, eMULTIPLICITY.ONCE)
                                      };
            outputHelp.Show(descs);

            string[] lines = output.getLines();

            CollectionAssert.AreEqual(
                new[]
                {
                    "Usage: GemsCLI [/options] [filename]",
                    "Where options include:",
                    "/width The width of the rectangle.",
                    "filename* The input file.",
                    "* shows optional parameters."
                },
                lines);
        }
    }
}