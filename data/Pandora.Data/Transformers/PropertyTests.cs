// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers;

public static class PropertiesTests
{
    [TestCase]
    public static void MapShouldFailWithoutJsonArgument()
    {
        foreach (var property in new WithoutArgumentExample().GetType().GetProperties())
        {
            Assert.Throws<Exception>(() => Property.Map(property, typeof(WithoutArgumentExample).FullName!));
        }
    }

    [TestCase]
    public static void MappingADictionaryOfIntegerStringShouldFail()
    {
        foreach (var property in new TypeContainingDictionaryIntegerString().GetType().GetProperties())
        {
            Assert.Throws<Exception>(() => Property.Map(property, typeof(TypeContainingDictionaryIntegerString).FullName!));
        }
    }

    [TestCase]
    public static void MapMapsProperties()
    {
        foreach (var property in new Foo().GetType().GetProperties())
        {
            var actual = Property.Map(property, typeof(Foo).FullName!);
            Assert.NotNull(actual);

            switch (property.Name)
            {
                case "AbstractType":
                    {
                        Assert.AreEqual("AbstractType", actual.Name);
                        Assert.AreEqual("abstractType", actual.JsonName);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.Type);
                        Assert.AreEqual("SomeParentType", actual.ObjectDefinition.ReferenceName);
                        Assert.IsTrue(actual.IsTypeHint);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicBoolField":
                    {
                        Assert.AreEqual("BasicBoolField", actual.Name);
                        Assert.AreEqual("basicBoolField", actual.JsonName);
                        Assert.AreEqual(ObjectType.Boolean, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicDateField":
                    {
                        Assert.AreEqual("BasicDateField", actual.Name);
                        Assert.AreEqual("basicDateField", actual.JsonName);
                        Assert.AreEqual(ObjectType.DateTime, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicDictionaryOfString":
                    {
                        Assert.AreEqual("BasicDictionaryOfString", actual.Name);
                        Assert.AreEqual("basicDictionaryOfString", actual.JsonName);
                        Assert.AreEqual(ObjectType.Dictionary, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.NotNull(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(ObjectType.String, actual.ObjectDefinition.NestedItem.Type);
                        Assert.Null(actual.ObjectDefinition.NestedItem.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicEdgeZoneField":
                    {
                        Assert.AreEqual("BasicEdgeZoneField", actual.Name);
                        Assert.AreEqual("basicEdgeZoneField", actual.JsonName);
                        Assert.AreEqual(ObjectType.EdgeZone, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicIntField":
                    {
                        Assert.AreEqual("BasicIntField", actual.Name);
                        Assert.AreEqual("basicIntField", actual.JsonName);
                        Assert.AreEqual(ObjectType.Integer, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicLocationField":
                    {
                        Assert.AreEqual("BasicLocationField", actual.Name);
                        Assert.AreEqual("basicLocationField", actual.JsonName);
                        Assert.AreEqual(ObjectType.Location, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicObjectField":
                    {
                        Assert.AreEqual("BasicObjectField", actual.Name);
                        Assert.AreEqual("basicObjectField", actual.JsonName);
                        Assert.AreEqual(ObjectType.RawObject, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicStringField":
                    {
                        Assert.AreEqual("BasicStringField", actual.Name);
                        Assert.AreEqual("basicStringField", actual.JsonName);
                        Assert.AreEqual(ObjectType.String, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicTagsField":
                    {
                        Assert.AreEqual("BasicTagsField", actual.Name);
                        Assert.AreEqual("basicTagsField", actual.JsonName);
                        Assert.AreEqual(ObjectType.Tags, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicSystemAssignedIdentityField":
                    {
                        Assert.AreEqual("BasicSystemAssignedIdentityField", actual.Name);
                        Assert.AreEqual("basicSystemAssignedIdentityField", actual.JsonName);
                        Assert.AreEqual(ObjectType.SystemAssignedIdentity, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicLegacySystemAndUserAssignedIdentityListField":
                    {
                        Assert.AreEqual("BasicLegacySystemAndUserAssignedIdentityListField", actual.Name);
                        Assert.AreEqual("basicLegacySystemAndUserAssignedIdentityListField", actual.JsonName);
                        Assert.AreEqual(ObjectType.LegacySystemAndUserAssignedIdentityList, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicLegacySystemAndUserAssignedIdentityMapField":
                    {
                        Assert.AreEqual("BasicLegacySystemAndUserAssignedIdentityMapField", actual.Name);
                        Assert.AreEqual("basicLegacySystemAndUserAssignedIdentityMapField", actual.JsonName);
                        Assert.AreEqual(ObjectType.LegacySystemAndUserAssignedIdentityMap, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicSystemAndUserAssignedIdentityListField":
                    {
                        Assert.AreEqual("BasicSystemAndUserAssignedIdentityListField", actual.Name);
                        Assert.AreEqual("basicSystemAndUserAssignedIdentityListField", actual.JsonName);
                        Assert.AreEqual(ObjectType.SystemAndUserAssignedIdentityList, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicSystemAndUserAssignedIdentityMapField":
                    {
                        Assert.AreEqual("BasicSystemAndUserAssignedIdentityMapField", actual.Name);
                        Assert.AreEqual("basicSystemAndUserAssignedIdentityMapField", actual.JsonName);
                        Assert.AreEqual(ObjectType.SystemAndUserAssignedIdentityMap, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicSystemOrUserAssignedIdentityListField":
                    {
                        Assert.AreEqual("BasicSystemOrUserAssignedIdentityListField", actual.Name);
                        Assert.AreEqual("basicSystemOrUserAssignedIdentityListField", actual.JsonName);
                        Assert.AreEqual(ObjectType.SystemOrUserAssignedIdentityList, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicSystemOrUserAssignedIdentityMapField":
                    {
                        Assert.AreEqual("BasicSystemOrUserAssignedIdentityMapField", actual.Name);
                        Assert.AreEqual("basicSystemOrUserAssignedIdentityMapField", actual.JsonName);
                        Assert.AreEqual(ObjectType.SystemOrUserAssignedIdentityMap, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicUserAssignedIdentityListField":
                    {
                        Assert.AreEqual("BasicUserAssignedIdentityListField", actual.Name);
                        Assert.AreEqual("basicUserAssignedIdentityListField", actual.JsonName);
                        Assert.AreEqual(ObjectType.UserAssignedIdentityList, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "BasicUserAssignedIdentityMapField":
                    {
                        Assert.AreEqual("BasicUserAssignedIdentityMapField", actual.Name);
                        Assert.AreEqual("basicUserAssignedIdentityMapField", actual.JsonName);
                        Assert.AreEqual(ObjectType.UserAssignedIdentityMap, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "Constant":
                    {
                        Assert.AreEqual("Constant", actual.Name);
                        Assert.AreEqual("constant", actual.JsonName);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.Type);
                        Assert.AreEqual("SomeEnum", actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "DateTime":
                    {
                        Assert.AreEqual("DateTime", actual.Name);
                        Assert.AreEqual("dateTime", actual.JsonName);
                        Assert.AreEqual(ObjectType.DateTime, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        Assert.AreEqual("RFC3339", actual.DateFormat);
                        continue;
                    }

                case "DictionaryOfAnObject":
                    {
                        Assert.AreEqual("DictionaryOfAnObject", actual.Name);
                        Assert.AreEqual("dictionaryOfAnObject", actual.JsonName);
                        Assert.AreEqual(ObjectType.Dictionary, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.NotNull(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.NestedItem.Type);
                        Assert.AreEqual("SomeOtherType", actual.ObjectDefinition.NestedItem.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "Float":
                    {
                        Assert.AreEqual("Float", actual.Name);
                        Assert.AreEqual("float", actual.JsonName);
                        Assert.AreEqual(ObjectType.Float, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "ListOfOtherEnum":
                    {
                        Assert.AreEqual("ListOfOtherEnum", actual.Name);
                        Assert.AreEqual("listOfOtherEnum", actual.JsonName);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.NotNull(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.NestedItem.Type);
                        Assert.AreEqual("SomeEnum", actual.ObjectDefinition.NestedItem.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "ListOfOtherType":
                    {
                        Assert.AreEqual("ListOfOtherType", actual.Name);
                        Assert.AreEqual("listOfOtherType", actual.JsonName);
                        Assert.AreEqual(ObjectType.List, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.NotNull(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.NestedItem.Type);
                        Assert.AreEqual("SomeOtherType", actual.ObjectDefinition.NestedItem.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "NestedObject":
                    {
                        Assert.AreEqual("NestedObject", actual.Name);
                        Assert.AreEqual("nestedObject", actual.JsonName);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.Type);
                        Assert.AreEqual("NestedType", actual.ObjectDefinition.ReferenceName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "OptionalBool":
                    {
                        Assert.AreEqual("OptionalBool", actual.Name);
                        Assert.AreEqual("optionalBool", actual.JsonName);
                        Assert.AreEqual(ObjectType.Boolean, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "OptionalConstant":
                    {
                        Assert.AreEqual("OptionalConstant", actual.Name);
                        Assert.AreEqual("optionalConstant", actual.JsonName);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.Type);
                        Assert.AreEqual("SomeEnum", actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "OptionalDateTime":
                    {
                        Assert.AreEqual("OptionalDateTime", actual.Name);
                        Assert.AreEqual("optionalDateTime", actual.JsonName);
                        Assert.AreEqual(ObjectType.DateTime, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        Assert.AreEqual("RFC3339", actual.DateFormat);
                        continue;
                    }

                case "OptionalInt":
                    {
                        Assert.AreEqual("OptionalInt", actual.Name);
                        Assert.AreEqual("optionalInt", actual.JsonName);
                        Assert.AreEqual(ObjectType.Integer, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "OptionalFloat":
                    {
                        Assert.AreEqual("OptionalFloat", actual.Name);
                        Assert.AreEqual("optionalFloat", actual.JsonName);
                        Assert.AreEqual(ObjectType.Float, actual.ObjectDefinition.Type);
                        Assert.Null(actual.ObjectDefinition.ReferenceName);
                        Assert.Null(actual.ObjectDefinition.NestedItem);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "OptionalNestedObject":
                    {
                        Assert.AreEqual("OptionalNestedObject", actual.Name);
                        Assert.AreEqual("optionalNestedObject", actual.JsonName);
                        Assert.AreEqual(ObjectType.Reference, actual.ObjectDefinition.Type);
                        Assert.AreEqual("NestedType", actual.ObjectDefinition.ReferenceName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "WithDefaultValueInt":
                    {
                        Assert.AreEqual("WithDefaultValueInt", actual.Name);
                        Assert.AreEqual("withDefaultValueInt", actual.JsonName);
                        Assert.AreEqual(21, actual.Default);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "WithDefaultValueString":
                    {
                        Assert.AreEqual("WithDefaultValueString", actual.Name);
                        Assert.AreEqual("withDefaultValueString", actual.JsonName);
                        Assert.AreEqual("Hello", actual.Default);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "WithForceNew":
                    {
                        Assert.AreEqual("WithForceNew", actual.Name);
                        Assert.AreEqual("withForceNew", actual.JsonName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(true, actual.ForceNew);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "WithOptional":
                    {
                        Assert.AreEqual("WithOptional", actual.Name);
                        Assert.AreEqual("withOptional", actual.JsonName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        continue;
                    }

                case "WithRequired":
                    {
                        Assert.AreEqual("WithRequired", actual.Name);
                        Assert.AreEqual("withRequired", actual.JsonName);
                        Assert.AreEqual(false, actual.Optional);
                        Assert.AreEqual(true, actual.Required);
                        continue;
                    }

                case "WithRangeValidation":
                    {
                        Assert.AreEqual("WithRangeValidation", actual.Name);
                        Assert.AreEqual("withRangeValidation", actual.JsonName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        Assert.NotNull(actual.Validation);
                        Assert.AreEqual(ValidationType.Range, actual.Validation.ValidationType);
                        Assert.AreEqual(new List<object> { 1, 20 }, actual.Validation.Values);
                        continue;
                    }

                case "ListWithMinMaxItems":
                    {
                        Assert.AreEqual("ListWithMinMaxItems", actual.Name);
                        Assert.AreEqual("listWithMinMaxItems", actual.JsonName);
                        Assert.AreEqual(true, actual.Optional);
                        Assert.AreEqual(false, actual.Required);
                        Assert.AreEqual(1, actual.ObjectDefinition.Minimum);
                        Assert.AreEqual(10, actual.ObjectDefinition.Maximum);
                        continue;
                    }

                default:
                    throw new NotSupportedException($"unhandled property {property.Name}");
            }
        }
    }

    private class Foo
    {
        [JsonPropertyName("abstractType")]
        [Optional]
        [ProvidesTypeHint]
        public SomeParentType AbstractType { get; set; }

        [JsonPropertyName("basicBoolField")]
        public bool BasicBoolField { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("basicDateField")]
        public DateTime BasicDateField { get; set; }

        [JsonPropertyName("basicDictionaryOfString")]
        public Dictionary<string, string> BasicDictionaryOfString { get; set; }

        [JsonPropertyName("basicEdgeZoneField")]
        public EdgeZone BasicEdgeZoneField { get; set; }

        [JsonPropertyName("basicLocationField")]
        public Location BasicLocationField { get; set; }

        [JsonPropertyName("basicIntField")]
        public int BasicIntField { get; set; }

        [JsonPropertyName("basicObjectField")]
        public object BasicObjectField { get; set; }

        [JsonPropertyName("basicStringField")]
        public string BasicStringField { get; set; }

        [JsonPropertyName("basicTagsField")]
        public Tags BasicTagsField { get; set; }

        [JsonPropertyName("basicSystemAssignedIdentityField")]
        public SystemAssignedIdentity BasicSystemAssignedIdentityField { get; set; }

        [JsonPropertyName("basicSystemAndUserAssignedIdentityListField")]
        public SystemAndUserAssignedIdentityList BasicSystemAndUserAssignedIdentityListField { get; set; }

        [JsonPropertyName("basicSystemAndUserAssignedIdentityMapField")]
        public SystemAndUserAssignedIdentityMap BasicSystemAndUserAssignedIdentityMapField { get; set; }

        [JsonPropertyName("basicLegacySystemAndUserAssignedIdentityListField")]
        public LegacySystemAndUserAssignedIdentityList BasicLegacySystemAndUserAssignedIdentityListField { get; set; }

        [JsonPropertyName("basicLegacySystemAndUserAssignedIdentityMapField")]
        public LegacySystemAndUserAssignedIdentityMap BasicLegacySystemAndUserAssignedIdentityMapField { get; set; }

        [JsonPropertyName("basicSystemOrUserAssignedIdentityListField")]
        public SystemOrUserAssignedIdentityList BasicSystemOrUserAssignedIdentityListField { get; set; }

        [JsonPropertyName("basicSystemOrUserAssignedIdentityMapField")]
        public SystemOrUserAssignedIdentityMap BasicSystemOrUserAssignedIdentityMapField { get; set; }

        [JsonPropertyName("basicUserAssignedIdentityListField")]
        public UserAssignedIdentityList BasicUserAssignedIdentityListField { get; set; }

        [JsonPropertyName("basicUserAssignedIdentityMapField")]
        public UserAssignedIdentityMap BasicUserAssignedIdentityMapField { get; set; }

        [JsonPropertyName("constant")]
        [Optional]
        public SomeEnum Constant { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("float")]
        public float Float { get; set; }

        [JsonPropertyName("listOfOtherEnum")]
        [Optional]
        public List<SomeEnum> ListOfOtherEnum { get; set; }

        [JsonPropertyName("listOfOtherType")]
        [Optional]
        public List<SomeOtherType> ListOfOtherType { get; set; }

        [JsonPropertyName("nestedObject")]
        [Optional]
        public NestedType NestedObject { get; set; }

        [JsonPropertyName("optionalBool")]
        [Optional]
        public bool? OptionalBool { get; set; }

        [JsonPropertyName("optionalConstant")]
        [Optional]
        public SomeEnum? OptionalConstant { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("optionalDateTime")]
        [Optional]
        public DateTime? OptionalDateTime { get; set; }

        [JsonPropertyName("dictionaryOfAnObject")]
        public Dictionary<string, SomeOtherType> DictionaryOfAnObject { get; set; }

        [JsonPropertyName("optionalFloat")]
        public float? OptionalFloat { get; set; }

        [JsonPropertyName("optionalInt")]
        [Optional]
        public int? OptionalInt { get; set; }

        [JsonPropertyName("withDefaultValueInt")]
        [Optional(DefaultValue = 21)]
        public string WithDefaultValueInt { get; set; }

        [JsonPropertyName("withDefaultValueString")]
        [Optional(DefaultValue = "Hello")]
        public string WithDefaultValueString { get; set; }

        [JsonPropertyName("optionalNestedObject")]
        [Optional]
        public NestedType? OptionalNestedObject { get; set; }

        [JsonPropertyName("withForceNew")]
        [Optional]
        [ForceNew]
        public string WithForceNew { get; set; }

        [JsonPropertyName("withOptional")]
        [Optional]
        public string WithOptional { get; set; }

        [JsonPropertyName("withRequired")]
        [Required]
        public string WithRequired { get; set; }

        [FieldValidation(Type = FieldValidationType.Range, StartRange = 1, EndRange = 20)]
        [JsonPropertyName("withRangeValidation")]
        [Optional]
        public int WithRangeValidation { get; set; }

        [JsonPropertyName("listWithMinMaxItems")]
        [Optional]
        [MinItems(1)]
        [MaxItems(10)]
        public List<int> ListWithMinMaxItems { get; set; }
    }

    public enum SomeEnum
    {
        First,
        Second
    }

    public class SomeOtherType
    {
    }

    public class NestedType
    {
        [JsonPropertyName("nestedField")]
        public bool NestedField { get; set; }
    }

    private class WithoutArgumentExample
    {
        public bool HasNoArgument { get; set; }
    }

    private abstract class SomeParentType
    {
        [JsonPropertyName("objectType")]
        [ProvidesTypeHint]
        public string ObjectType { get; set; }
    }

    private class TypeContainingDictionaryIntegerString
    {
        [JsonPropertyName("someDictionary")]
        public Dictionary<int, string> SomeDictionary { get; set; }
    }
}