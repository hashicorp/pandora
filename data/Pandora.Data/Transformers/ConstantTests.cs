// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers;

public class ConstantTests
{
    [TestCase]
    public void MappingANonObjectShouldReturnAnError()
    {
        Assert.Throws<Exception>(() => Constant.FromEnum(typeof(List<string>)));
    }

    [TestCase]
    public void MappingABasicEnum()
    {
        var actual = Constant.FromEnum(new ExampleConstant().GetType());
        Assert.NotNull(actual);
        Assert.AreEqual(false, actual.CaseInsensitive);
        Assert.AreEqual(ConstantType.String, actual.Type);
        Assert.AreEqual("Example", actual.Name);
        Assert.AreEqual(2, actual.Values.Count);
        Assert.AreEqual("first", actual.Values["First"]);
        Assert.AreEqual("second", actual.Values["Second"]);
    }

    [TestCase]
    public void MappingWithACaseSensitiveAttribute()
    {
        var actual = Constant.FromEnum(new CaseInsensitiveExample().GetType());
        Assert.NotNull(actual);
        Assert.AreEqual(true, actual.CaseInsensitive);
        Assert.AreEqual(ConstantType.String, actual.Type);
        Assert.AreEqual("CaseInsensitiveExample", actual.Name);
        Assert.AreEqual(2, actual.Values.Count);
        Assert.AreEqual("first", actual.Values["First"]);
        Assert.AreEqual("second", actual.Values["Second"]);
    }

    [TestCase]
    public void MappingAFloatEnum()
    {
        var actual = Constant.FromEnum(new EnumAsFloats().GetType());
        Assert.NotNull(actual);
        Assert.AreEqual(false, actual.CaseInsensitive);
        Assert.AreEqual(ConstantType.Float, actual.Type);
        Assert.AreEqual("EnumAsFloats", actual.Name);
        Assert.AreEqual(2, actual.Values.Count);
        Assert.AreEqual("1.0", actual.Values["OnePointZero"]);
        Assert.AreEqual("2.20103", actual.Values["TwoPointTwoZeroOneZeroThree"]);
    }

    [TestCase]
    public void MappingAnIntegerEnum()
    {
        var actual = Constant.FromEnum(new EnumAsIntegers().GetType());
        Assert.NotNull(actual);
        Assert.AreEqual(false, actual.CaseInsensitive);
        Assert.AreEqual(ConstantType.Integer, actual.Type);
        Assert.AreEqual("EnumAsIntegers", actual.Name);
        Assert.AreEqual(2, actual.Values.Count);
        Assert.AreEqual("1", actual.Values["One"]);
        Assert.AreEqual("2", actual.Values["Two"]);
    }

    [TestCase]
    public void MappingContainingEqualsShouldMapCorrectly()
    {
        var actual = Constant.FromEnum(new EnumContainingEquals().GetType());
        Assert.NotNull(actual);
        Assert.AreEqual(false, actual.CaseInsensitive);
        Assert.AreEqual(ConstantType.String, actual.Type);
        Assert.AreEqual("EnumContainingEquals", actual.Name);
        Assert.AreEqual(3, actual.Values.Count);
        Assert.AreEqual("equals", actual.Values["Equals"]);
        Assert.AreEqual("multiply", actual.Values["Multiply"]);
        Assert.AreEqual("subtract", actual.Values["Subtract"]);
    }

    [TestCase]
    public void MappingWithoutAConstantTypeAttribute()
    {
        Assert.Throws<Exception>(() => Constant.FromEnum(new EnumWithoutConstantType().GetType()));
    }

    [TestCase]
    public void MappingWithoutDescriptionsShouldFail()
    {
        Assert.Throws<Exception>(() => Constant.FromEnum(new EnumMissingAttribute().GetType()));
    }

    [TestCase]
    public void MappingAClassShouldFail()
    {
        Assert.Throws<Exception>(() => Constant.FromEnum(new ClassWithoutEnum().GetType()));
    }

    private class ClassWithoutEnum
    {
        public bool Hello { get; set; }
    }

    private class ClassWithSingleEnum
    {
        public ExampleConstant Prop { get; set; }
    }

    private class ClassWithNestedClassContainingAnEnum
    {
        public ClassWithSingleEnum Inner { get; set; }
    }

    private class ClassWithNestedClasses
    {
        public ClassWithNestedClassContainingAnEnum First { get; set; }

        public ClassWithNestedClassContainingAnEnum Second { get; set; }
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum ExampleConstant
    {
        [System.ComponentModel.Description("first")]
        First,

        [System.ComponentModel.Description("second")]
        Second
    }

    [CaseInsensitiveDueToApiBug("example-for-acctest")]
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum CaseInsensitiveExample
    {
        [System.ComponentModel.Description("first")]
        First,

        [System.ComponentModel.Description("second")]
        Second
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.Float)]
    private enum EnumAsFloats
    {
        [System.ComponentModel.Description("1.0")]
        OnePointZero,

        [System.ComponentModel.Description("2.20103")]
        TwoPointTwoZeroOneZeroThree,
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
    private enum EnumAsIntegers
    {
        [System.ComponentModel.Description("1")]
        One,

        [System.ComponentModel.Description("2")]
        Two,
    }

    private enum EnumWithoutConstantType
    {
        [System.ComponentModel.Description("first")]
        First,
        [System.ComponentModel.Description("second")]
        Second,
    }

    private enum EnumMissingAttribute
    {
        [System.ComponentModel.Description("first")]
        First,

        // intentionally missing the description
        Second
    }

    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    private enum EnumContainingEquals
    {
        [System.ComponentModel.Description("equals")]
        Equals,

        [System.ComponentModel.Description("multiply")]
        Multiply,

        [System.ComponentModel.Description("subtract")]
        Subtract,
    }
}