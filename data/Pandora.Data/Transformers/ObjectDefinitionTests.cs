using System;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class ObjectDefinitionTests
    {
        [TestCase]
        public static void MappingNullShouldThrowAnException()
        {
            Assert.Throws<NotSupportedException>(() => ObjectDefinition.Map(null!));
        }

        [TestCase]
        public static void MappingABoolean()
        {
            var actual = ObjectDefinition.Map(typeof(bool));
            Assert.AreEqual(ObjectType.Boolean, actual.Type);
            Assert.Null(actual.ReferenceName);
        }

        [TestCase]
        public static void MappingADictionary()
        {
            // TODO: this'll also need an ItemType property
            Assert.Fail("not implemented");
        }

        [TestCase]
        public static void MappingAnEnum()
        {
            var actual = ObjectDefinition.Map(typeof(SomeConstant));
            Assert.AreEqual(ObjectType.Reference, actual.Type);
            Assert.NotNull(actual.ReferenceName);
            Assert.AreEqual("Some", actual.ReferenceName);
        }

        [TestCase]
        public static void MappingAFloat()
        {
            var actual = ObjectDefinition.Map(typeof(float));
            Assert.AreEqual(ObjectType.Float, actual.Type);
            Assert.Null(actual.ReferenceName);
        }

        [TestCase]
        public static void MappingAnInteger()
        {
            var actual = ObjectDefinition.Map(typeof(int));
            Assert.AreEqual(ObjectType.Integer, actual.Type);
            Assert.Null(actual.ReferenceName);
        }

        [TestCase]
        public static void MappingAList()
        {
            // TODO: this'll also need an ItemType property
            Assert.Fail("not implemented");
        }

        [TestCase]
        public static void MappingAnObject()
        {
            var actual = ObjectDefinition.Map(typeof(SomeModel));
            Assert.AreEqual(ObjectType.Reference, actual.Type);
            Assert.NotNull(actual.ReferenceName);
            Assert.AreEqual("Some", actual.ReferenceName);
        }

        [TestCase]
        public static void MappingAString()
        {
            var actual = ObjectDefinition.Map(typeof(string));
            Assert.AreEqual(ObjectType.String, actual.Type);
            Assert.Null(actual.ReferenceName);
        }

        private class SomeModel
        {
            [JsonPropertyName("foo")]
            public string Foo { get; set; }
        }

        private enum SomeConstant
        {
            [System.ComponentModel.Description("first")]
            First,
            
            [System.ComponentModel.Description("second")]
            Second,
        }
    }
}