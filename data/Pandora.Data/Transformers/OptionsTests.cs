using System.Linq;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class OptionsTests
    {
        [TestCase]
        public static void MappingAnEmptyObject()
        {
            var actual = Options.Map(typeof(OptionsObjectEmpty));
            Assert.AreEqual(actual.Count, 0);
        }

        [TestCase]
        public static void MappingAnObjectContainingJustSimpleTypes()
        {
            var actual = Options.Map(typeof(OptionsObjectContainingSimpleTypes));
            Assert.AreEqual(actual.Count, 3);

            var someBool = actual.First(o => o.Name == "SomeBool");
            Assert.True(someBool.Required);
            Assert.AreEqual(someBool.QueryStringName, "someBool");
            Assert.AreEqual(someBool.Type, OptionDefinitionType.Boolean);
            Assert.Null(someBool.ConstantType);

            var someInt = actual.First(o => o.Name == "SomeInt");
            Assert.False(someInt.Required);
            Assert.AreEqual(someInt.QueryStringName, "someInt");
            Assert.AreEqual(someInt.Type, OptionDefinitionType.Integer);
            Assert.Null(someInt.ConstantType);

            var someString = actual.First(o => o.Name == "SomeString");
            Assert.True(someString.Required);
            Assert.AreEqual(someString.QueryStringName, "someString");
            Assert.AreEqual(someString.Type, OptionDefinitionType.String);
            Assert.Null(someString.ConstantType);
        }

        [TestCase]
        public static void MappingAnObjectContainingAConstant()
        {
            var actual = Options.Map(typeof(OptionsObjectContainingAConstant));
            Assert.AreEqual(actual.Count, 2);

            var someString = actual.First(o => o.Name == "SomeString");
            Assert.True(someString.Required);
            Assert.AreEqual(someString.QueryStringName, "someString");
            Assert.AreEqual(someString.Type, OptionDefinitionType.String);
            Assert.Null(someString.ConstantType);

            var someConst = actual.First(o => o.Name == "SomeConst");
            Assert.True(someConst.Required);
            Assert.AreEqual(someConst.QueryStringName, "someConst");
            Assert.AreEqual(someConst.Type, OptionDefinitionType.Constant);
            Assert.AreEqual(someConst.ConstantType, "SomeOther");
        }

        private class OptionsObjectEmpty
        {
        }

        private class OptionsObjectContainingSimpleTypes
        {
            [QueryStringName("someBool")]
            public bool SomeBool { get; set; }

            [QueryStringName("someInt")]
            [Optional]
            public int SomeInt { get; set; }

            [QueryStringName("someString")]
            public string SomeString { get; set; }
        }

        private class OptionsObjectContainingAConstant
        {
            [QueryStringName("someConst")]
            public SomeOtherConstant SomeConst { get; set; }

            [QueryStringName("someString")]
            public string SomeString { get; set; }
        }

        private enum SomeOtherConstant
        {
        }
    }
}