using System.Collections.Generic;
using GemsCLI.Arguments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Arguments
{
    [TestClass]
    public class ArgumentFactoryTests
    {
        [TestMethod]
        public void Create_0()
        {
            List<Argument> args = ArgumentFactory.Create("/", "=",
                new[] {"/debug=on", "house", "/filter", "document.txt", "input"});

            Assert.AreEqual(5, args.Count);

            Assert.AreEqual("debug", args[0].Name);
            Assert.AreEqual("on", args[0].Value);
            Assert.AreEqual(0, args[0].Index);

            Assert.IsTrue(args[1] is ArgumentPassed);
            Assert.AreEqual(0, ((ArgumentPassed)args[1]).Order);
            Assert.AreEqual("house", args[1].Value);
            Assert.AreEqual(1, args[1].Index);

            Assert.AreEqual("filter", args[2].Name);
            Assert.IsNull(args[2].Value);
            Assert.AreEqual(2, args[2].Index);

            Assert.IsTrue(args[3] is ArgumentPassed);
            Assert.AreEqual(1, ((ArgumentPassed)args[3]).Order);
            Assert.AreEqual("document.txt", args[3].Value);
            Assert.AreEqual(3, args[3].Index);

            Assert.IsTrue(args[4] is ArgumentPassed);
            Assert.AreEqual(2, ((ArgumentPassed)args[4]).Order);
            Assert.AreEqual("input", args[4].Value);
            Assert.AreEqual(4, args[4].Index);
        }

        [TestMethod]
        public void Create_1()
        {
            ArgumentNamed arg = ArgumentFactory.Create(2, "/", "=", "/debug=on") as ArgumentNamed;
            Assert.IsNotNull(arg);
            Assert.AreEqual("debug", arg.Name);
            Assert.AreEqual("on", arg.Value);
            Assert.AreEqual(2, arg.Index);
        }

        [TestMethod]
        public void ExtractName()
        {
            Assert.IsNull(ArgumentFactory.ExtractName("/", "=", ""));
            Assert.IsNull(ArgumentFactory.ExtractName("/", "=", "/="));
            Assert.IsNull(ArgumentFactory.ExtractName("/", "=", "/=on"));

            Assert.AreEqual("debug", ArgumentFactory.ExtractName("/", "=", "/debug"));
            Assert.AreEqual("debug", ArgumentFactory.ExtractName("/", "=", "/debug=on"));
            Assert.AreEqual("debug", ArgumentFactory.ExtractName("/", "=", "debug"));
            Assert.AreEqual("debug", ArgumentFactory.ExtractName("/", "=", "debug=on"));
        }

        [TestMethod]
        public void ExtractValue()
        {
            Assert.IsNull(ArgumentFactory.ExtractValue("/", "=", ""));
            Assert.IsNull(ArgumentFactory.ExtractValue("/", "=", "/debug"));

            Assert.AreEqual("on", ArgumentFactory.ExtractValue("/", "=", "/debug=on"));
            Assert.AreEqual("on", ArgumentFactory.ExtractValue("/", "=", "/debug=on"));
            Assert.AreEqual("debug", ArgumentFactory.ExtractValue("/", "=", "debug"));
            Assert.AreEqual("document.txt", ArgumentFactory.ExtractValue("/", "=", "document.txt"));
        }
    }
}