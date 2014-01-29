using System.Collections.Generic;
using System.Linq;
using GemsCLI;
using GemsCLI.Descriptions;
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
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(), "/width:int");
            Request request = RequestFactory.Create(new[]{"/height:99"}, descs);

            Description[] missingRequired = GemsCLI.Validators.Validator.MissingRequired(descs, request).ToArray();

            Assert.AreEqual(1,missingRequired.Length);
            Assert.AreEqual("width",missingRequired[0].Name);
        }

        [TestMethod]
        public void SelectDuplicates()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(), "/width:int");
            Request request = RequestFactory.Create(new[] { "/width:10", "/width:20" }, descs);

            Description[] duplicates = GemsCLI.Validators.Validator.SelectDuplicates(descs, request).ToArray();

            Assert.AreEqual(1, duplicates.Length);
            Assert.AreEqual("width", duplicates[0].Name);
        }

        [TestMethod]
        public void SelectMissingValue()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(), "/width:int");
            Request request = RequestFactory.Create(new[] { "/width" }, descs);

            Description[] missingValue = GemsCLI.Validators.Validator.SelectMissingValue(descs, request).ToArray();

            Assert.AreEqual(1, missingValue.Length);
            Assert.AreEqual("width", missingValue[0].Name);
        }

        [TestMethod]
        public void Validate()
        {
            List<Description> descs = DescriptionFactory.Create(CliOptions.WindowsStyle, new MockHelpProvider(), "/width:int");
            Validator v = new Validator(new MockOutput());

            Assert.IsTrue(v.Validate(descs, RequestFactory.Create(new[] { "/width:10" }, descs)));
            Assert.IsFalse(v.Validate(descs, RequestFactory.Create(new string[0], descs)));
            Assert.IsFalse(v.Validate(descs, RequestFactory.Create(new[] { "/width:10", "/width:10" }, descs)));
            Assert.IsFalse(v.Validate(descs, RequestFactory.Create(new[] { "10" }, descs)));
        }

        [TestMethod]
        public void Validator()
        {
            Validator v = new Validator(new MockOutput());
        }
    }
}