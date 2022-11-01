using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaObjectDefinitionTests
{
    // TODO: tests for Sets

    [TestCase]
    public static void MappingBasicTypes()
    {
        var basicTypes = new Dictionary<Type, TerraformSchemaFieldType>
        {
            {typeof(bool), TerraformSchemaFieldType.Boolean},
            {typeof(DateTime), TerraformSchemaFieldType.DateTime},
            {typeof(float), TerraformSchemaFieldType.Float},
            {typeof(int), TerraformSchemaFieldType.Integer},
            {typeof(string), TerraformSchemaFieldType.String},
        };
        foreach (var basicType in basicTypes)
        {
            var result = TerraformSchemaObjectDefinition.Map(basicType.Key);
            Assert.NotNull(result);
            Assert.AreEqual(basicType.Value, result.Type);
            Assert.Null(result.NestedObject);
            Assert.Null(result.ReferenceName);
        }
    }

    [TestCase]
    public static void MappingBasicTypesWithinAList()
    {
        var basicTypes = new Dictionary<Type, TerraformSchemaFieldType>
        {
            {typeof(List<bool>), TerraformSchemaFieldType.Boolean},
            {typeof(List<DateTime>), TerraformSchemaFieldType.DateTime},
            {typeof(List<float>), TerraformSchemaFieldType.Float},
            {typeof(List<int>), TerraformSchemaFieldType.Integer},
            {typeof(List<string>), TerraformSchemaFieldType.String},
        };
        foreach (var basicType in basicTypes)
        {
            var result = TerraformSchemaObjectDefinition.Map(basicType.Key);
            Assert.NotNull(result);
            Assert.AreEqual(TerraformSchemaFieldType.List, result.Type);
            Assert.NotNull(result.NestedObject);
            Assert.Null(result.ReferenceName);
            Assert.AreEqual(basicType.Value, result.NestedObject.Type);
            Assert.Null(result.NestedObject.ReferenceName);
            Assert.Null(result.NestedObject.NestedObject);
        }
    }

    [TestCase]
    public static void MappingBasicTypesWithinAListOfAList()
    {
        var basicTypes = new Dictionary<Type, TerraformSchemaFieldType>
        {
            {typeof(List<List<bool>>), TerraformSchemaFieldType.Boolean},
            {typeof(List<List<DateTime>>), TerraformSchemaFieldType.DateTime},
            {typeof(List<List<float>>), TerraformSchemaFieldType.Float},
            {typeof(List<List<int>>), TerraformSchemaFieldType.Integer},
            {typeof(List<List<string>>), TerraformSchemaFieldType.String},
        };
        foreach (var basicType in basicTypes)
        {
            var result = TerraformSchemaObjectDefinition.Map(basicType.Key);
            Assert.NotNull(result);
            Assert.AreEqual(TerraformSchemaFieldType.List, result.Type);
            Assert.NotNull(result.NestedObject);
            Assert.Null(result.ReferenceName);
            Assert.AreEqual(TerraformSchemaFieldType.List, result.NestedObject.Type);
            Assert.Null(result.NestedObject.ReferenceName);
            Assert.NotNull(result.NestedObject.NestedObject);
            Assert.AreEqual(basicType.Value, result.NestedObject.NestedObject.Type);
            Assert.Null(result.NestedObject.NestedObject.ReferenceName);
            Assert.Null(result.NestedObject.NestedObject.NestedObject);
        }
    }

    [TestCase]
    public static void MappingCommonSchemaTypes()
    {
        var commonSchemaTypes = new Dictionary<Type, TerraformSchemaFieldType>
        {
            {typeof(EdgeZoneSingle), TerraformSchemaFieldType.EdgeZone},
            {typeof(SystemAssignedIdentity), TerraformSchemaFieldType.IdentitySystemAssigned},
            {typeof(SystemAndUserAssignedIdentity), TerraformSchemaFieldType.IdentitySystemAndUserAssigned},
            {typeof(SystemOrUserAssignedIdentity), TerraformSchemaFieldType.IdentitySystemOrUserAssigned},
            {typeof(UserAssignedIdentity), TerraformSchemaFieldType.IdentityUserAssigned},
            {typeof(Location), TerraformSchemaFieldType.Location},
            {typeof(ResourceGroupName), TerraformSchemaFieldType.ResourceGroup},
            {typeof(Tags), TerraformSchemaFieldType.Tags},
            {typeof(ZoneSingle), TerraformSchemaFieldType.Zone},
            {typeof(ZonesMultiple), TerraformSchemaFieldType.Zones},
        };
        foreach (var commonSchemaType in commonSchemaTypes)
        {
            var result = TerraformSchemaObjectDefinition.Map(commonSchemaType.Key);
            Assert.NotNull(result);
            Assert.AreEqual(commonSchemaType.Value, result.Type);
            Assert.Null(result.NestedObject);
            Assert.Null(result.ReferenceName);
        }
    }

    [TestCase]
    public static void MappingADictionaryOfBasicTypes()
    {
        var basicTypes = new Dictionary<Type, TerraformSchemaFieldType>
        {
            {typeof(Dictionary<string, bool>), TerraformSchemaFieldType.Boolean},
            {typeof(Dictionary<string, float>), TerraformSchemaFieldType.Float},
            {typeof(Dictionary<string, int>), TerraformSchemaFieldType.Integer},
            {typeof(Dictionary<string, string>), TerraformSchemaFieldType.String},
        };
        foreach (var basicType in basicTypes)
        {
            var result = TerraformSchemaObjectDefinition.Map(basicType.Key);
            Assert.NotNull(result);
            Assert.AreEqual(TerraformSchemaFieldType.Dictionary, result.Type);
            Assert.NotNull(result.NestedObject);
            Assert.Null(result.ReferenceName);
            Assert.AreEqual(basicType.Value, result.NestedObject.Type);
            Assert.Null(result.NestedObject.NestedObject);
            Assert.Null(result.NestedObject.ReferenceName);
        }
    }

    [TestCase]
    public static void MappingADictionaryOfComplexType()
    {
        var result = TerraformSchemaObjectDefinition.Map(typeof(Dictionary<string, SomeModel>));
        Assert.NotNull(result);
        Assert.AreEqual(TerraformSchemaFieldType.Dictionary, result.Type);
        Assert.NotNull(result.NestedObject);
        Assert.Null(result.ReferenceName);
        Assert.AreEqual(TerraformSchemaFieldType.Reference, result.NestedObject.Type);
        Assert.Null(result.NestedObject.NestedObject);
        Assert.NotNull(result.NestedObject.ReferenceName);
        Assert.AreEqual("SomeModel", result.NestedObject.ReferenceName);
    }

    [TestCase]
    public static void MappingAReference()
    {
        var result = TerraformSchemaObjectDefinition.Map(typeof(SomeModel));
        Assert.NotNull(result);
        Assert.AreEqual(TerraformSchemaFieldType.Reference, result.Type);
        Assert.Null(result.NestedObject);
        Assert.NotNull(result.ReferenceName);
        Assert.AreEqual("SomeModel", result.ReferenceName!);
    }

    [TestCase]
    public static void MappingAReferenceWithinAList()
    {
        var result = TerraformSchemaObjectDefinition.Map(typeof(List<SomeModel>));
        Assert.NotNull(result);
        Assert.AreEqual(TerraformSchemaFieldType.List, result.Type);
        Assert.NotNull(result.NestedObject);
        Assert.Null(result.ReferenceName);
        Assert.AreEqual(TerraformSchemaFieldType.Reference, result.NestedObject.Type);
        Assert.Null(result.NestedObject.NestedObject);
        Assert.NotNull(result.NestedObject.ReferenceName);
        Assert.AreEqual("SomeModel", result.NestedObject.ReferenceName!);
    }

    [TestCase]
    public static void MappingAReferenceWithinAListOfAList()
    {
        var result = TerraformSchemaObjectDefinition.Map(typeof(List<List<SomeModel>>));
        Assert.NotNull(result);
        Assert.AreEqual(TerraformSchemaFieldType.List, result.Type);
        Assert.NotNull(result.NestedObject);
        Assert.Null(result.ReferenceName);

        Assert.AreEqual(TerraformSchemaFieldType.List, result.NestedObject.Type);
        Assert.NotNull(result.NestedObject.NestedObject);
        Assert.Null(result.NestedObject.ReferenceName);

        Assert.AreEqual(TerraformSchemaFieldType.Reference, result.NestedObject.NestedObject.Type);
        Assert.Null(result.NestedObject.NestedObject.NestedObject);
        Assert.NotNull(result.NestedObject.NestedObject.ReferenceName);
        Assert.AreEqual("SomeModel", result.NestedObject.NestedObject.ReferenceName!);
    }

    private class SomeModel
    {
        [HclName("example")]
        [Optional]
        public bool Example { get; set; }
    }
}