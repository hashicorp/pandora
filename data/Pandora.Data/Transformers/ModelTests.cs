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
        // TODO: nested duplicate
        // TODO: lists

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
    }
}