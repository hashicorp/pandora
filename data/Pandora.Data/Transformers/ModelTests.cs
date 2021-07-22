using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class ModelTests
    {
        [TestCase]
        public static void MappingAModelContainingSelfReferences()
        {
            var actual = Model.Map(new ExampleWithSelfReferences());
            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Name);
            Assert.AreEqual(4, actual.First().Properties.Count);

            Assert.NotNull(actual.First().Properties.First(f => f.Name == "SelfReference").Name);
            Assert.AreEqual(PropertyType.Object, actual.First().Properties.First(f => f.Name == "SelfReference").PropertyType);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Properties.First(f => f.Name == "SelfReference").ModelReference);

            Assert.NotNull(actual.First().Properties.First(f => f.Name == "NilableSelfReference").Name);
            Assert.AreEqual(PropertyType.Object, actual.First().Properties.First(f => f.Name == "NilableSelfReference").PropertyType);
            Assert.True(actual.First().Properties.First(f => f.Name == "NilableSelfReference").Optional);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Properties.First(f => f.Name == "NilableSelfReference").ModelReference);

            Assert.NotNull(actual.First().Properties.First(f => f.Name == "ListOfReferences").Name);
            Assert.AreEqual(PropertyType.List, actual.First().Properties.First(f => f.Name == "ListOfReferences").PropertyType);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Properties.First(f => f.Name == "ListOfReferences").ModelReference);

            Assert.NotNull(actual.First().Properties.First(f => f.Name == "NilableListOfReferences").Name);
            Assert.AreEqual(PropertyType.List, actual.First().Properties.First(f => f.Name == "NilableListOfReferences").PropertyType);
            Assert.True(actual.First().Properties.First(f => f.Name == "NilableListOfReferences").Optional);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Properties.First(f => f.Name == "NilableListOfReferences").ModelReference);
        }

        [TestCase]
        public static void MappingAModelContainingLists()
        {
            var actual = Model.Map(new ExampleWithList());
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithList", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);
            Assert.AreEqual("OtherTypes", actual.First().Properties.First().Name);
            Assert.AreEqual(PropertyType.List, actual.First().Properties.First().PropertyType);
            Assert.AreEqual("OtherType", actual.First().Properties.First().ModelReference);
        }

        [TestCase]
        public static void TestMapModel()
        {
            var actual = Model.Map(new Example());
            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Example", actual.First().Name);
            Assert.AreEqual(3, actual.First().Properties.Count);

            foreach (var property in actual.First().Properties)
            {
                switch (property.Name)
                {
                    case "First":
                        {
                            Assert.AreEqual("first", property.JsonName);
                            Assert.AreEqual(PropertyType.Boolean, property.PropertyType);
                            Assert.AreEqual(true, property.Required);
                            continue;
                        }

                    case "Second":
                        {
                            Assert.AreEqual("second", property.JsonName);
                            Assert.AreEqual(PropertyType.String, property.PropertyType);
                            Assert.AreEqual(true, property.Optional);
                            continue;
                        }

                    case "Random":
                        {
                            Assert.AreEqual("barrelRoll", property.JsonName);
                            Assert.AreEqual(PropertyType.String, property.PropertyType);
                            Assert.AreEqual(true, property.Optional);
                            Assert.AreEqual("do a", property.Default);
                            continue;
                        }

                    default:
                        {
                            Assert.Fail($"unexpected property {property.Name}");
                            return;
                        }
                }
            }
        }

        [TestCase]
        public static void TestMapNestedModels()
        {
            var actual = Model.Map(new NestedWrapper());
            Assert.NotNull(actual);
            Assert.AreEqual(3, actual.Count);

            // First
            Assert.AreEqual("First", actual.First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);
            Assert.AreEqual("Field", actual.First().Properties.First().Name);

            // NestedWrapper
            Assert.AreEqual("NestedWrapper", actual.Skip(1).First().Name);
            Assert.AreEqual(2, actual.Skip(1).First().Properties.Count);
            Assert.AreEqual("First", actual.Skip(1).First().Properties.First().Name);
            Assert.AreEqual("First", actual.Skip(1).First().Properties.First().ModelReference);
            Assert.AreEqual("Second", actual.Skip(1).First().Properties.Skip(1).First().Name);
            Assert.AreEqual("Second", actual.Skip(1).First().Properties.Skip(1).First().ModelReference);

            // Second
            Assert.AreEqual("Second", actual.Skip(2).First().Name);
            Assert.AreEqual(1, actual.Skip(2).First().Properties.Count);
        }

        [TestCase]
        public static void TestMapDuplicateModels()
        {
            var actual = Model.Map(new DuplicateWrapper());
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);

            // DuplicateWrapper
            Assert.AreEqual("DuplicateWrapper", actual.First().Name);
            Assert.AreEqual(2, actual.First().Properties.Count);
            Assert.AreEqual("First", actual.First().Properties.First().Name);
            Assert.AreEqual("First", actual.First().Properties.First().ModelReference);
            Assert.AreEqual("Second", actual.First().Properties.Skip(1).First().Name);
            Assert.AreEqual("First", actual.First().Properties.Skip(1).First().ModelReference);

            // First
            Assert.AreEqual("First", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.Skip(1).First().Properties.Count);
            Assert.AreEqual("Field", actual.Skip(1).First().Properties.First().Name);
        }

        [Test]
        public static void TestMappingDiscriminatedTypes()
        {
            var actual = Model.Map(new AnimalsWrapper());
            Assert.NotNull(actual);
            Assert.AreEqual(4, actual.Count);

            var wrapper = actual.FirstOrDefault(t => t.Name == "AnimalsWrapper");
            Assert.NotNull(wrapper);
            Assert.AreEqual(2, wrapper.Properties.Count);
            Assert.Null(wrapper.ParentTypeName);
            Assert.Null(wrapper.TypeHintIn);
            Assert.Null(wrapper.TypeHintValue);

            var animal = actual.FirstOrDefault(t => t.Name == "Animal");
            Assert.NotNull(animal);
            Assert.AreEqual(1, animal.Properties.Count);
            Assert.Null(animal.ParentTypeName);
            Assert.AreEqual("ObjectType", animal.TypeHintIn);
            Assert.Null(animal.TypeHintValue);

            var cat = actual.FirstOrDefault(t => t.Name == "Cat");
            Assert.NotNull(cat);
            Assert.AreEqual(2, cat.Properties.Count);
            Assert.AreEqual("Animal", cat.ParentTypeName);
            Assert.AreEqual("ObjectType", cat.TypeHintIn);
            Assert.AreEqual("cat", cat.TypeHintValue);

            var dog = actual.FirstOrDefault(t => t.Name == "Dog");
            Assert.NotNull(dog);
            Assert.AreEqual(1, dog.Properties.Count);
            Assert.AreEqual("Animal", dog.ParentTypeName);
            Assert.AreEqual("ObjectType", dog.TypeHintIn);
            Assert.AreEqual("dog", dog.TypeHintValue);
        }

        private class Example
        {
            [JsonPropertyName("first")]
            [Required]
            public bool First { get; set; }

            [JsonPropertyName("second")]
            [Optional]
            public string Second { get; set; }

            [JsonPropertyName("barrelRoll")]
            [Optional(DefaultValue = "do a")]
            public string Random { get; set; }
        }

        private class ExampleWithList
        {
            [JsonPropertyName("otherTypes")]
            public List<OtherType> OtherTypes { get; set; }
        }

        private class OtherType
        {
            [JsonPropertyName("hello")]
            public bool Hello { get; set; }
        }

        private class DuplicateWrapper
        {
            [JsonPropertyName("first")]
            public First First { get; set; }

            [JsonPropertyName("second")]
            public First Second { get; set; }
        }

        private class NestedWrapper
        {
            [JsonPropertyName("first")]
            public First First { get; set; }

            [JsonPropertyName("second")]
            public Second Second { get; set; }
        }

        private class First
        {
            [JsonPropertyName("field")]
            [Optional]
            public bool Field { get; set; }
        }

        private class Second
        {
            [JsonPropertyName("field")]
            [Optional]
            public bool Field { get; set; }
        }

        private class AnimalsWrapper
        {
            [JsonPropertyName("animal")]
            public Animal Animal { get; set; }

            [JsonPropertyName("animals")]
            public List<Animal> Animals { get; set; }
        }

        private abstract class Animal
        {
            [JsonPropertyName("objectType")]
            [ProvidesTypeHint]
            public string ObjectType { get; set; }
        }

        [ValueForType("cat")]
        private class Cat : Animal
        {
            [JsonPropertyName("jumps")]
            public bool Jumps { get; set; }
        }

        [ValueForType("dog")]
        private class Dog : Animal
        {
        }
    }

    public class ExampleWithSelfReferences
    {
        [JsonPropertyName("listOfReferences")]
        public List<ExampleWithSelfReferences> ListOfReferences { get; set; }

        [JsonPropertyName("nilableListOfReferences")]
        public List<ExampleWithSelfReferences>? NilableListOfReferences { get; set; }

        [JsonPropertyName("nilableSelfReference")]
        public ExampleWithSelfReferences? NilableSelfReference { get; set; }

        [JsonPropertyName("selfReference")]
        public ExampleWithSelfReferences SelfReference { get; set; }
    }
}