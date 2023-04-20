using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers;

public static class ModelTests
{
    [TestCase]
    public static void MappingABuiltInTypeShouldReturnNothing()
    {
        var builtInTypes = new List<Type>
        {
            typeof(bool),
            typeof(int),
            typeof(float),
            typeof(string),
            typeof(Csv<bool>),
            typeof(Csv<int>),
            typeof(Csv<float>),
            typeof(Csv<string>),
            typeof(Dictionary<string, bool>),
            typeof(Dictionary<string, int>),
            typeof(Dictionary<string, float>),
            typeof(Dictionary<string, string>),
            typeof(List<bool>),
            typeof(List<int>),
            typeof(List<float>),
            typeof(List<string>),
            typeof(List<List<bool>>),
            typeof(List<List<int>>),
            typeof(List<List<float>>),
            typeof(List<List<string>>),
            typeof(List<List<List<bool>>>),
            typeof(List<List<List<int>>>),
            typeof(List<List<List<float>>>),
            typeof(List<List<List<string>>>),
        };

        foreach (var type in builtInTypes)
        {
            var actual = Model.Map(type);
            Assert.Null(actual);
        }
    }

    [TestCase]
    public static void MappingACsvOfAModelShouldReturnJustTheModel()
    {
        // contents are verified below, as long as we have it we're good
        var actual = Model.Map(typeof(Csv<Example>));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
    }

    [TestCase]
    public static void MappingADictionaryOfAModelShouldReturnJustTheModel()
    {
        // contents are verified below, as long as we have it we're good
        var actual = Model.Map(typeof(Dictionary<string, Example>));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
    }

    [TestCase]
    public static void MappingAListOfAModelShouldReturnJustTheModel()
    {
        // contents are verified below, as long as we have it we're good
        var actual = Model.Map(typeof(List<Example>));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
    }

    [TestCase]
    public static void MappingAListOfAListOfAModelShouldReturnJustTheModel()
    {
        // contents are verified below, as long as we have it we're good
        var actual = Model.Map(typeof(List<List<Example>>));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
    }

    [TestCase]
    public static void MappingAListOfAListOfAListOfAModelShouldReturnJustTheModel()
    {
        // contents are verified below, as long as we have it we're good
        var actual = Model.Map(typeof(List<List<List<Example>>>));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
    }

    [TestCase]
    public static void MappingAModelShouldRemoveSuffixes()
    {
        var actual = Model.Map(typeof(ExampleWithSuffixesModel));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithSuffixes", actual.Name);
        Assert.AreEqual(4, actual.Properties.Count);
        Assert.NotNull(actual.Properties.First(p => p.Name == "Bool"));
        Assert.NotNull(actual.Properties.First(p => p.Name == "Int"));
        Assert.NotNull(actual.Properties.First(p => p.Name == "SecondProp"));
        Assert.NotNull(actual.Properties.First(p => p.Name == "String"));
    }

    [TestCase]
    public static void MappingAModelContainingSelfReferences()
    {
        var actual = Model.Map(typeof(ExampleWithSelfReferences));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithSelfReferences", actual.Name);
        Assert.AreEqual(4, actual.Properties.Count);

        var selfReferenceProp = actual.Properties.First(f => f.Name == "SelfReference");
        Assert.NotNull(selfReferenceProp.Name);
        Assert.AreEqual(ObjectType.Reference, selfReferenceProp.ObjectDefinition.Type);
        Assert.AreEqual("ExampleWithSelfReferences", selfReferenceProp.ObjectDefinition.ReferenceName);

        var nilableSelfReferenceProp = actual.Properties.First(f => f.Name == "NilableSelfReference");
        Assert.NotNull(nilableSelfReferenceProp.Name);
        Assert.AreEqual(ObjectType.Reference, nilableSelfReferenceProp.ObjectDefinition.Type);
        Assert.True(nilableSelfReferenceProp.Optional);
        Assert.AreEqual("ExampleWithSelfReferences", nilableSelfReferenceProp.ObjectDefinition.ReferenceName);

        var listOfReferencesProp = actual.Properties.First(f => f.Name == "ListOfReferences");
        Assert.NotNull(listOfReferencesProp.Name);
        Assert.AreEqual(ObjectType.List, listOfReferencesProp.ObjectDefinition.Type);
        Assert.Null(listOfReferencesProp.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, listOfReferencesProp.ObjectDefinition.NestedItem.Type);
        Assert.AreEqual("ExampleWithSelfReferences", listOfReferencesProp.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(listOfReferencesProp.ObjectDefinition.NestedItem.NestedItem);

        var nilableListOfReferencesProp = actual.Properties.First(f => f.Name == "NilableListOfReferences");
        Assert.NotNull(nilableSelfReferenceProp.Name);
        Assert.AreEqual(ObjectType.List, listOfReferencesProp.ObjectDefinition.Type);
        Assert.Null(listOfReferencesProp.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, listOfReferencesProp.ObjectDefinition.NestedItem.Type);
        Assert.AreEqual("ExampleWithSelfReferences", nilableListOfReferencesProp.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(nilableListOfReferencesProp.ObjectDefinition.NestedItem.NestedItem);
        Assert.True(nilableListOfReferencesProp.Optional);
    }

    [TestCase]
    public static void MappingAModelContainingLists()
    {
        var actual = Model.Map(typeof(ExampleWithList));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithList", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAModelContainingNullableLists()
    {
        var actual = Model.Map(typeof(ExampleWithNullableList));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithNullableList", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAModelContainingAListOfLists()
    {
        var actual = Model.Map(typeof(ExampleWithListOfLists));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithListOfLists", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAModelContainingNullableListOfLists()
    {
        var actual = Model.Map(typeof(ExampleWithNullableListOfLists));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithNullableListOfLists", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);
        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAModelContainingAListOfListsOfLists()
    {
        var actual = Model.Map(typeof(ExampleWithListOfListsOfLists));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithListOfListsOfLists", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);

        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);

        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAModelContainingNullableListOfListsOfLists()
    {
        var actual = Model.Map(typeof(ExampleWithNullableListOfListsOfLists));
        Assert.NotNull(actual);
        Assert.AreEqual("ExampleWithNullableListOfListsOfLists", actual.Name);
        Assert.AreEqual(1, actual.Properties.Count);

        var prop = actual.Properties.First();
        Assert.AreEqual("OtherTypes", prop.Name);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
        Assert.Null(prop.ObjectDefinition.ReferenceName);
        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);

        Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.NestedItem.Type);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);

        Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.Type);
        Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.ReferenceName);
        Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.NestedItem);
    }

    [TestCase]
    public static void TestMapModel()
    {
        var actual = Model.Map(typeof(Example));
        Assert.NotNull(actual);
        Assert.AreEqual("Example", actual.Name);
        Assert.AreEqual(3, actual.Properties.Count);

        foreach (var property in actual.Properties)
        {
            switch (property.Name)
            {
                case "First":
                    {
                        Assert.AreEqual("first", property.JsonName);
                        Assert.AreEqual(ObjectType.Boolean, property.ObjectDefinition.Type);
                        Assert.AreEqual(true, property.Required);
                        continue;
                    }

                case "Second":
                    {
                        Assert.AreEqual("second", property.JsonName);
                        Assert.AreEqual(ObjectType.String, property.ObjectDefinition.Type);
                        Assert.AreEqual(true, property.Optional);
                        continue;
                    }

                case "Random":
                    {
                        Assert.AreEqual("barrelRoll", property.JsonName);
                        Assert.AreEqual(ObjectType.String, property.ObjectDefinition.Type);
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
    public static void TestMappingAModelContainingANullableConstant()
    {
        var actual = Model.Map(typeof(QuotaModel));
        Assert.NotNull(actual);
        Assert.AreEqual("Quota", actual.Name);
    }

    [TestCase]
    public static void TestMappingADiscriminatedParentType()
    {
        var actual = Model.Map(typeof(ParentType));
        Assert.NotNull(actual);
        Assert.AreEqual("ParentType", actual.Name);
        Assert.Null(actual.ParentTypeName);
        Assert.AreEqual("Example", actual.TypeHintIn);
        Assert.Null(actual.TypeHintValue);
    }

    [TestCase]
    public static void TestMappingADiscriminatedImplementation()
    {
        var actual = Model.Map(typeof(ImplementationType));
        Assert.NotNull(actual);
        Assert.AreEqual("ImplementationType", actual.Name);
        Assert.NotNull(actual.ParentTypeName);
        Assert.AreEqual("ParentType", actual.ParentTypeName);
        Assert.NotNull(actual.TypeHintIn);
        Assert.AreEqual("Example", actual.TypeHintIn);
        Assert.NotNull(actual.TypeHintValue);
        Assert.AreEqual("LetGo", actual.TypeHintValue);
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

    private class ExampleWithNullableList
    {
        [JsonPropertyName("otherTypes")]
        public List<OtherType>? OtherTypes { get; set; }
    }

    private class ExampleWithListOfLists
    {
        [JsonPropertyName("otherTypes")]
        public List<List<OtherType>> OtherTypes { get; set; }
    }

    private class ExampleWithNullableListOfLists
    {
        [JsonPropertyName("otherTypes")]
        public List<List<OtherType>>? OtherTypes { get; set; }
    }

    private class ExampleWithListOfListsOfLists
    {
        [JsonPropertyName("otherTypes")]
        public List<List<List<OtherType>>> OtherTypes { get; set; }
    }

    private class ExampleWithNullableListOfListsOfLists
    {
        [JsonPropertyName("otherTypes")]
        public List<List<List<OtherType>>>? OtherTypes { get; set; }
    }

    private class OtherType
    {
        [JsonPropertyName("hello")]
        public bool Hello { get; set; }
    }

    internal class QuotaModel
    {
        [JsonPropertyName("hostsRemaining")]
        public Dictionary<string, int>? HostsRemaining { get; set; }

        [JsonPropertyName("quotaEnabled")]
        public QuotaEnabledConstant? QuotaEnabled { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum QuotaEnabledConstant
    {
        [System.ComponentModel.Description("Disabled")]
        Disabled,

        [System.ComponentModel.Description("Enabled")]
        Enabled,
    }

    private class ExampleWithSuffixesModel
    {
        [JsonPropertyName("bool")]
        public bool Bool { get; set; }

        [JsonPropertyName("int")]
        public int Int { get; set; }

        [JsonPropertyName("secondProp")]
        public SecondModel SecondProp { get; set; }

        [JsonPropertyName("string")]
        public string String { get; set; }
    }

    private class SecondModel
    {
        [JsonPropertyName("field")]
        [Optional]
        public bool Field { get; set; }
    }

    private class ExampleWithSelfReferences
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

    private abstract class ParentType
    {
        [ProvidesTypeHint]
        [JsonPropertyName("example")]
        [Required]
        public string Example { get; set; }
    }

    [ValueForType("LetGo")]
    private class ImplementationType : ParentType
    {
        [JsonPropertyName("complicated")]
        public bool Complicated { get; set; }
    }
}
