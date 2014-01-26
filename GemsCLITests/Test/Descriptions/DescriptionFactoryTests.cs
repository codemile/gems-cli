using System.Collections.Generic;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Exceptions;
using GemsCLI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Descriptions
{
    [TestClass]
    public class DescriptionFactoryTests
    {
        private static void AssertMultiple(ParserOptions pOptions, string pPattern)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pPattern);
            Assert.AreEqual(eMULTIPLICITY.MULTIPLE, desc.Multiplicity);

            AssertOptional(pOptions, "[" + pPattern + "]");
        }

        private static void AssertNamed(ParserOptions pOptions, string pPattern)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pPattern);
            Assert.AreEqual(eROLE.NAMED, desc.Role);

            AssertTypes(pOptions, pPattern);
        }

        private static void AssertOptional(ParserOptions pOptions, string pPattern)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pPattern);
            Assert.AreEqual(eSCOPE.OPTIONAL, desc.Scope);
        }

        private static void AssertParsable(ParserOptions pOptions, string pName)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pName);
            Assert.AreEqual(pName, desc.Name);
            Assert.AreEqual(eSCOPE.REQUIRED, desc.Scope);
            Assert.AreEqual(eMULTIPLICITY.ONCE, desc.Multiplicity);

            AssertPassed(pOptions, pName);
            AssertNamed(pOptions, pOptions.Prefix + pName);
        }

        private static void AssertPassed(ParserOptions pOptions, string pPattern)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pPattern);
            Assert.AreEqual(eROLE.PASSED, desc.Role);

            AssertMultiple(pOptions, pPattern + "#");
            AssertTypes(pOptions, pPattern);
        }

        private static void AssertType<T>(ParserOptions pOptions, string pPattern)
        {
            Description desc = DescriptionFactory.Parse(pOptions, pPattern);
            Assert.IsNotNull(desc.Type);
            Assert.IsTrue(desc.Type is T);

            AssertMultiple(pOptions, pPattern + "#");
            AssertOptional(pOptions, "[" + pPattern + "]");
        }

        private static void AssertTypes(ParserOptions pOptions, string pPattern)
        {
            AssertType<ParamString>(pOptions, pPattern + pOptions.EqualChar + "string");
            AssertType<ParamInt>(pOptions, pPattern + pOptions.EqualChar + "int");
        }

        [TestMethod]
        public void Create()
        {
            List<Description> descs = DescriptionFactory
                .Create(
                    ParserOptions.WindowsStyle,
                    "/debug /database:STRING /port:int# [/UserName:string] filename [INPUT:int#]"
                );

            Assert.AreEqual(6, descs.Count);

            Assert.AreEqual(eROLE.NAMED, descs[0].Role);
            Assert.AreEqual(eROLE.NAMED, descs[1].Role);
            Assert.AreEqual(eROLE.NAMED, descs[2].Role);
            Assert.AreEqual(eROLE.NAMED, descs[3].Role);
            Assert.AreEqual(eROLE.PASSED, descs[4].Role);
            Assert.AreEqual(eROLE.PASSED, descs[5].Role);

            Assert.AreEqual("debug", descs[0].Name);
            Assert.AreEqual("database", descs[1].Name);
            Assert.AreEqual("port", descs[2].Name);
            Assert.AreEqual("username", descs[3].Name);
            Assert.AreEqual("filename", descs[4].Name);
            Assert.AreEqual("input", descs[5].Name);

            Assert.IsNull(descs[0].Type);
            Assert.IsTrue(descs[1].Type is ParamString);
            Assert.IsTrue(descs[2].Type is ParamInt);
            Assert.IsTrue(descs[3].Type is ParamString);
            Assert.IsTrue(descs[4].Type is ParamString);
            Assert.IsTrue(descs[5].Type is ParamInt);

            Assert.AreEqual(eMULTIPLICITY.ONCE, descs[0].Multiplicity);
            Assert.AreEqual(eMULTIPLICITY.ONCE, descs[1].Multiplicity);
            Assert.AreEqual(eMULTIPLICITY.MULTIPLE, descs[2].Multiplicity);
            Assert.AreEqual(eMULTIPLICITY.ONCE, descs[3].Multiplicity);
            Assert.AreEqual(eMULTIPLICITY.ONCE, descs[4].Multiplicity);
            Assert.AreEqual(eMULTIPLICITY.MULTIPLE, descs[5].Multiplicity);

            Assert.AreEqual(eSCOPE.REQUIRED, descs[0].Scope);
            Assert.AreEqual(eSCOPE.REQUIRED, descs[1].Scope);
            Assert.AreEqual(eSCOPE.REQUIRED, descs[2].Scope);
            Assert.AreEqual(eSCOPE.OPTIONAL, descs[3].Scope);
            Assert.AreEqual(eSCOPE.REQUIRED, descs[4].Scope);
            Assert.AreEqual(eSCOPE.OPTIONAL, descs[5].Scope);
        }

        [TestMethod]
        public void Parse_0()
        {
            string[] terms = {"debug", "path", "database", "x"};
            ParserOptions[] options = {ParserOptions.BasicStyle, ParserOptions.WindowsStyle, ParserOptions.LinuxStyle};
            foreach (ParserOptions option in options)
            {
                foreach (string term in terms)
                {
                    AssertParsable(option, term);
                }
            }
        }

        [TestMethod]
        public void Parse_1()
        {
            string[] invalidStrings =
            {
                "/debug#", "", "/", "[]", "[/debug", "/debug]", "/debug:xxxx", "xxx:xxx",
                "[:xxx]", ":", "23473", "1abc"
            };

            foreach (string invalid in invalidStrings)
            {
                try
                {
                    Description desc = DescriptionFactory.Parse(ParserOptions.WindowsStyle, invalid);
                    Assert.Fail("Expected SyntaxErrorException for {0}", invalid);
                }
                catch (SyntaxErrorException)
                {
                }
            }
        }
    }
}