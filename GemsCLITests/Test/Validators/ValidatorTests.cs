using System.Collections.Generic;
using System.Linq;
using GemsCLI;
using GemsCLI.Descriptions;
using GemsCLI.Output;
using GemsCLI.Validators;
using GemsCLITests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GemsCLITests.Test.Validators
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void MissingRequired()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(),
                "/width:int");
            Request request = RequestFactory.Create(CliOptions.WindowsStyle, new[] {"/height:99"}, descs,
                new MockOutputFactory());

            Description[] missingRequired = Validator.MissingRequired(descs, request).ToArray();

            Assert.AreEqual(1, missingRequired.Length);
            Assert.AreEqual("width", missingRequired[0].Name);
        }

        [TestMethod]
        public void SelectDuplicates()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(),
                "/width:int");
            Request request = RequestFactory.Create(CliOptions.WindowsStyle, new[] {"/width:10", "/width:20"}, descs,
                new MockOutputFactory());

            Description[] duplicates = Validator.SelectDuplicates(descs, request).ToArray();

            Assert.AreEqual(1, duplicates.Length);
            Assert.AreEqual("width", duplicates[0].Name);
        }

        [TestMethod]
        public void SelectMissingValue()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(),
                "/width:int");
            Request request = RequestFactory.Create(CliOptions.WindowsStyle, new[] {"/width"}, descs,
                new MockOutputFactory());

            Description[] missingValue = Validator.SelectMissingValue(descs, request).ToArray();

            Assert.AreEqual(1, missingValue.Length);
            Assert.AreEqual("width", missingValue[0].Name);
        }

        [TestMethod]
        public void Validate()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(),
                "/width:int");
            Validator v = new Validator(new OutputMessages(CliOptions.WindowsStyle, new MockOutput()));

            Assert.IsTrue(v.Validate(descs,
                RequestFactory.Create(CliOptions.WindowsStyle, new[] {"/width:10"}, descs, new MockOutputFactory())));
            Assert.IsFalse(v.Validate(descs,
                RequestFactory.Create(CliOptions.WindowsStyle, new string[0], descs, new MockOutputFactory())));
            Assert.IsFalse(v.Validate(descs,
                RequestFactory.Create(CliOptions.WindowsStyle, new[] {"/width:10", "/width:10"}, descs,
                    new MockOutputFactory())));
            Assert.IsFalse(v.Validate(descs,
                RequestFactory.Create(CliOptions.WindowsStyle, new[] {"10"}, descs, new MockOutputFactory())));
        }

        [TestMethod]
        public void Validator_0()
        {
            Validator v = new Validator(new OutputMessages(CliOptions.WindowsStyle, new MockOutput()));
        }

        [TestMethod]
        public void Validator_1()
        {
            Validator v = new Validator(null);

            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(),
                "/width:int");
            Request request = RequestFactory.Create(CliOptions.WindowsStyle, new string[0], descs,
                new MockOutputFactory());

            Assert.IsTrue(v.Validate(descs, request));
        }
    }
}