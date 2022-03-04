using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers;

public static class OptionsTests
{
    [TestCase]
    public static void MappingAnEmptyObject()
    {
        var actual = Options.Map(typeof(OptionsObjectEmpty));
        Assert.AreEqual(actual.Count, 0);
    }

    [TestCase]
    public static void MappingAnObjectContainingJustSimpleTypesQueryString()
    {
        var actual = Options.Map(typeof(OptionsObjectContainingSimpleTypesQueryString));
        Assert.AreEqual(actual.Count, 3);

        var someBool = actual.First(o => o.Name == "SomeBool");
        Assert.True(someBool.Required);
        Assert.AreEqual("someBool", someBool.QueryStringName);
        Assert.AreEqual(ObjectType.Boolean, someBool.ObjectDefinition.Type);
        Assert.Null(someBool.ObjectDefinition.ReferenceName);
        Assert.Null(someBool.ObjectDefinition.NestedItem);

        var someInt = actual.First(o => o.Name == "SomeInt");
        Assert.False(someInt.Required);
        Assert.AreEqual("someInt", someInt.QueryStringName);
        Assert.AreEqual(ObjectType.Integer, someInt.ObjectDefinition.Type);
        Assert.Null(someInt.ObjectDefinition.ReferenceName);
        Assert.Null(someInt.ObjectDefinition.NestedItem);

        var someString = actual.First(o => o.Name == "SomeString");
        Assert.True(someString.Required);
        Assert.AreEqual("someString", someString.QueryStringName);
        Assert.AreEqual(ObjectType.String, someString.ObjectDefinition.Type);
        Assert.Null(someString.ObjectDefinition.ReferenceName);
        Assert.Null(someString.ObjectDefinition.NestedItem);
    }

    [TestCase]
    public static void MappingAnObjectContainingAConstantQueryString()
    {
        var actual = Options.Map(typeof(OptionsObjectContainingAConstantQueryString));
        Assert.AreEqual(actual.Count, 2);

        var someString = actual.First(o => o.Name == "SomeString");
        Assert.True(someString.Required);
        Assert.AreEqual("someString", someString.QueryStringName);
        Assert.AreEqual(ObjectType.String, someString.ObjectDefinition.Type);
        Assert.Null(someString.ObjectDefinition.ReferenceName);
        Assert.Null(someString.ObjectDefinition.NestedItem);

        var someConst = actual.First(o => o.Name == "SomeConst");
        Assert.True(someConst.Required);
        Assert.AreEqual("someConst", someConst.QueryStringName);
        Assert.AreEqual(ObjectType.Reference, someConst.ObjectDefinition.Type);
        Assert.AreEqual("SomeOther", someConst.ObjectDefinition.ReferenceName);
        Assert.Null(someConst.ObjectDefinition.NestedItem);
    }

    [TestCase]
    public static void MappingAnObjectContainingCsvsQueryString()
    {
        var actual = Options.Map(typeof(OptionsObjectContainingCsvsQueryString));
        Assert.AreEqual(3, actual.Count);

        var floatCsv = actual.First(o => o.Name == "CsvOfFloats");
        Assert.True(floatCsv.Required);
        Assert.AreEqual("csvOfFloats", floatCsv.QueryStringName);
        Assert.AreEqual(ObjectType.Csv, floatCsv.ObjectDefinition.Type);
        Assert.Null(floatCsv.ObjectDefinition.ReferenceName);
        Assert.NotNull(floatCsv.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Float, floatCsv.ObjectDefinition.NestedItem.Type);
        Assert.Null(floatCsv.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(floatCsv.ObjectDefinition.NestedItem.NestedItem);

        var intCsv = actual.First(o => o.Name == "CsvOfIntegers");
        Assert.True(intCsv.Required);
        Assert.AreEqual("csvOfIntegers", intCsv.QueryStringName);
        Assert.AreEqual(ObjectType.Csv, intCsv.ObjectDefinition.Type);
        Assert.Null(intCsv.ObjectDefinition.ReferenceName);
        Assert.NotNull(intCsv.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Integer, intCsv.ObjectDefinition.NestedItem.Type);
        Assert.Null(intCsv.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(intCsv.ObjectDefinition.NestedItem.NestedItem);

        var stringCsv = actual.First(o => o.Name == "CsvOfStrings");
        Assert.True(stringCsv.Required);
        Assert.AreEqual("csvOfStrings", stringCsv.QueryStringName);
        Assert.AreEqual(ObjectType.Csv, stringCsv.ObjectDefinition.Type);
        Assert.Null(stringCsv.ObjectDefinition.ReferenceName);
        Assert.NotNull(stringCsv.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.String, stringCsv.ObjectDefinition.NestedItem.Type);
        Assert.Null(stringCsv.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(stringCsv.ObjectDefinition.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAnObjectContainingDictionariesQueryString()
    {
        var actual = Options.Map(typeof(OptionsObjectContainingDictionariesQueryString));
        Assert.AreEqual(3, actual.Count);

        var floatDictionary = actual.First(o => o.Name == "DictionaryOfFloats");
        Assert.True(floatDictionary.Required);
        Assert.AreEqual("dictionaryOfFloats", floatDictionary.QueryStringName);
        Assert.AreEqual(ObjectType.Dictionary, floatDictionary.ObjectDefinition.Type);
        Assert.Null(floatDictionary.ObjectDefinition.ReferenceName);
        Assert.NotNull(floatDictionary.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Float, floatDictionary.ObjectDefinition.NestedItem.Type);
        Assert.Null(floatDictionary.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(floatDictionary.ObjectDefinition.NestedItem.NestedItem);

        var integerDictionary = actual.First(o => o.Name == "DictionaryOfIntegers");
        Assert.True(integerDictionary.Required);
        Assert.AreEqual("dictionaryOfIntegers", integerDictionary.QueryStringName);
        Assert.AreEqual(ObjectType.Dictionary, integerDictionary.ObjectDefinition.Type);
        Assert.Null(integerDictionary.ObjectDefinition.ReferenceName);
        Assert.NotNull(integerDictionary.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Integer, integerDictionary.ObjectDefinition.NestedItem.Type);
        Assert.Null(integerDictionary.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(integerDictionary.ObjectDefinition.NestedItem.NestedItem);

        var stringDictionary = actual.First(o => o.Name == "DictionaryOfStrings");
        Assert.True(stringDictionary.Required);
        Assert.AreEqual("dictionaryOfStrings", stringDictionary.QueryStringName);
        Assert.AreEqual(ObjectType.Dictionary, stringDictionary.ObjectDefinition.Type);
        Assert.Null(stringDictionary.ObjectDefinition.ReferenceName);
        Assert.NotNull(stringDictionary.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.String, stringDictionary.ObjectDefinition.NestedItem.Type);
        Assert.Null(stringDictionary.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(stringDictionary.ObjectDefinition.NestedItem.NestedItem);
    }

    [TestCase]
    public static void MappingAnObjectContainingListsQueryString()
    {
        var actual = Options.Map(typeof(OptionsObjectContainingListsQueryString));
        Assert.AreEqual(3, actual.Count);

        var floatList = actual.First(o => o.Name == "ListOfFloats");
        Assert.True(floatList.Required);
        Assert.AreEqual("listOfFloats", floatList.QueryStringName);
        Assert.AreEqual(ObjectType.List, floatList.ObjectDefinition.Type);
        Assert.Null(floatList.ObjectDefinition.ReferenceName);
        Assert.NotNull(floatList.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Float, floatList.ObjectDefinition.NestedItem.Type);
        Assert.Null(floatList.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(floatList.ObjectDefinition.NestedItem.NestedItem);

        var intList = actual.First(o => o.Name == "ListOfIntegers");
        Assert.True(intList.Required);
        Assert.AreEqual("listOfIntegers", intList.QueryStringName);
        Assert.AreEqual(ObjectType.List, intList.ObjectDefinition.Type);
        Assert.Null(intList.ObjectDefinition.ReferenceName);
        Assert.NotNull(intList.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.Integer, intList.ObjectDefinition.NestedItem.Type);
        Assert.Null(intList.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(intList.ObjectDefinition.NestedItem.NestedItem);

        var stringList = actual.First(o => o.Name == "ListOfStrings");
        Assert.True(stringList.Required);
        Assert.AreEqual("listOfStrings", stringList.QueryStringName);
        Assert.AreEqual(ObjectType.List, stringList.ObjectDefinition.Type);
        Assert.Null(stringList.ObjectDefinition.ReferenceName);
        Assert.NotNull(stringList.ObjectDefinition.NestedItem);
        Assert.AreEqual(ObjectType.String, stringList.ObjectDefinition.NestedItem.Type);
        Assert.Null(stringList.ObjectDefinition.NestedItem.ReferenceName);
        Assert.Null(stringList.ObjectDefinition.NestedItem.NestedItem);
    }

    private class OptionsObjectEmpty
    {
    }

    private class OptionsObjectContainingSimpleTypesQueryString
    {
        [QueryStringName("someBool")]
        public bool SomeBool { get; set; }

        [QueryStringName("someInt")]
        [Optional]
        public int SomeInt { get; set; }

        [QueryStringName("someString")]
        public string SomeString { get; set; }
    }

    private class OptionsObjectContainingAConstantQueryString
    {
        [QueryStringName("someConst")]
        public SomeOtherConstant SomeConst { get; set; }

        [QueryStringName("someString")]
        public string SomeString { get; set; }
    }

    private class OptionsObjectContainingCsvsQueryString
    {
        [QueryStringName("csvOfFloats")]
        public Csv<float> CsvOfFloats { get; set; }

        [QueryStringName("csvOfIntegers")]
        public Csv<int> CsvOfIntegers { get; set; }

        [QueryStringName("csvOfStrings")]
        public Csv<string> CsvOfStrings { get; set; }
    }

    private class OptionsObjectContainingDictionariesQueryString
    {
        [QueryStringName("dictionaryOfFloats")]
        public Dictionary<string, float> DictionaryOfFloats { get; set; }

        [QueryStringName("dictionaryOfIntegers")]
        public Dictionary<string, int> DictionaryOfIntegers { get; set; }

        [QueryStringName("dictionaryOfStrings")]
        public Dictionary<string, string> DictionaryOfStrings { get; set; }
    }

    private class OptionsObjectContainingListsQueryString
    {
        [QueryStringName("listOfFloats")]
        public List<float> ListOfFloats { get; set; }

        [QueryStringName("listOfIntegers")]
        public List<int> ListOfIntegers { get; set; }

        [QueryStringName("listOfStrings")]
        public List<string> ListOfStrings { get; set; }
    }

    private enum SomeOtherConstant
    {
    }
}