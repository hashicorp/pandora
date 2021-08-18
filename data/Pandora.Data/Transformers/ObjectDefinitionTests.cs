using System;
using System.Collections.Generic;
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
            Assert.Null(actual.NestedItem);
        }

        [TestCase]
        public static void MappingADictionaryOfAnObject()
        {
            var actual = ObjectDefinition.Map(typeof(Dictionary<string, SomeModel>));
            Assert.AreEqual(ObjectType.Dictionary, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.Reference, actual.NestedItem!.Type);
            Assert.NotNull(actual.NestedItem!.ReferenceName);
            Assert.AreEqual("Some", actual.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingADictionaryOfString()
        {
            var actual = ObjectDefinition.Map(typeof(Dictionary<string, string>));
            Assert.AreEqual(ObjectType.Dictionary, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.String, actual.NestedItem!.Type);
            Assert.Null(actual.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAnEnum()
        {
            var actual = ObjectDefinition.Map(typeof(SomeConstant));
            Assert.AreEqual(ObjectType.Reference, actual.Type);
            Assert.NotNull(actual.ReferenceName);
            Assert.AreEqual("Some", actual.ReferenceName);
            Assert.Null(actual.NestedItem);
        }

        [TestCase]
        public static void MappingAFloat()
        {
            var actual = ObjectDefinition.Map(typeof(float));
            Assert.AreEqual(ObjectType.Float, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.Null(actual.NestedItem);
        }

        [TestCase]
        public static void MappingAnInteger()
        {
            var actual = ObjectDefinition.Map(typeof(int));
            Assert.AreEqual(ObjectType.Integer, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.Null(actual.NestedItem);
        }

        [TestCase]
        public static void MappingAListOfObject()
        {
            var actual = ObjectDefinition.Map(typeof(List<SomeModel>));
            Assert.AreEqual(ObjectType.List, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.Reference, actual.NestedItem!.Type);
            Assert.NotNull(actual.NestedItem!.ReferenceName);
            Assert.AreEqual("Some", actual.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAListOfListOfAnObject()
        {
            var actual = ObjectDefinition.Map(typeof(List<List<SomeModel>>));
            Assert.AreEqual(ObjectType.List, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.List, actual.NestedItem!.Type);
            Assert.Null(actual.NestedItem!.ReferenceName);
            Assert.NotNull(actual.NestedItem!.NestedItem);
            Assert.AreEqual(ObjectType.Reference, actual.NestedItem!.NestedItem!.Type);
            Assert.AreEqual("Some", actual.NestedItem!.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAListOfString()
        {
            var actual = ObjectDefinition.Map(typeof(List<string>));
            Assert.AreEqual(ObjectType.List, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.String, actual.NestedItem!.Type);
            Assert.Null(actual.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAListOfListOfString()
        {
            var actual = ObjectDefinition.Map(typeof(List<List<string>>));
            Assert.AreEqual(ObjectType.List, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.NotNull(actual.NestedItem);
            Assert.AreEqual(ObjectType.List, actual.NestedItem!.Type);
            Assert.Null(actual.NestedItem!.ReferenceName);
            Assert.NotNull(actual.NestedItem!.NestedItem);
            Assert.AreEqual(ObjectType.String, actual.NestedItem!.NestedItem!.Type);
            Assert.Null(actual.NestedItem!.NestedItem!.ReferenceName);
            Assert.Null(actual.NestedItem!.NestedItem!.NestedItem);
        }

        [TestCase]
        public static void MappingAnObject()
        {
            var actual = ObjectDefinition.Map(typeof(SomeModel));
            Assert.AreEqual(ObjectType.Reference, actual.Type);
            Assert.NotNull(actual.ReferenceName);
            Assert.AreEqual("Some", actual.ReferenceName);
            Assert.Null(actual.NestedItem);
        }

        [TestCase]
        public static void MappingAString()
        {
            var actual = ObjectDefinition.Map(typeof(string));
            Assert.AreEqual(ObjectType.String, actual.Type);
            Assert.Null(actual.ReferenceName);
            Assert.Null(actual.NestedItem);
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