using System;
using GemsCLI.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Attributes
{
    [TestClass]
    public class CliHelpTests
    {
        [TestMethod]
        public void CliHelp_0()
        {
            CliHelp cliHelp = new CliHelp("The help message.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CliHelp_1()
        {
            CliHelp cliHelp = new CliHelp("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CliHelp_2()
        {
            CliHelp cliHelp = new CliHelp(null);
        }
    }
}