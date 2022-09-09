using System.Collections.Generic;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldValidationDefinitionTests
{
    [TestCase]
    public static void MappingPossibleValuesAsFloat()
    {
        var input = typeof(ModelContainingAFieldWithFixedPossibleValues).GetProperty("WithPossibleValuesAsFloat");
        Assert.NotNull(input);

        var actual = TerraformSchemaFieldValidationDefinition.Map(input);
        Assert.AreEqual(TerraformSchemaFieldValidationType.PossibleValues, actual.Type);
        Assert.NotNull(actual.PossibleValues);
        Assert.AreEqual(TerraformSchemaFieldValidationPossibleType.Float, actual.PossibleValues.Type);
        Assert.AreEqual(new List<string> { "3.14" }, actual.PossibleValues!.Values);
    }

    [TestCase]
    public static void MappingPossibleValuesAsInteger()
    {
        var input = typeof(ModelContainingAFieldWithFixedPossibleValues).GetProperty("WithPossibleValuesAsInteger");
        Assert.NotNull(input);

        var actual = TerraformSchemaFieldValidationDefinition.Map(input);
        Assert.AreEqual(TerraformSchemaFieldValidationType.PossibleValues, actual.Type);
        Assert.NotNull(actual.PossibleValues);
        Assert.AreEqual(TerraformSchemaFieldValidationPossibleType.Int, actual.PossibleValues.Type);
        Assert.AreEqual(new List<string> { "21", "42" }, actual.PossibleValues!.Values);
    }

    [TestCase]
    public static void MappingPossibleValuesAsString()
    {
        var input = typeof(ModelContainingAFieldWithFixedPossibleValues).GetProperty("WithPossibleValuesAsString");
        Assert.NotNull(input);

        var actual = TerraformSchemaFieldValidationDefinition.Map(input);
        Assert.AreEqual(TerraformSchemaFieldValidationType.PossibleValues, actual.Type);
        Assert.NotNull(actual.PossibleValues);
        Assert.AreEqual(TerraformSchemaFieldValidationPossibleType.String, actual.PossibleValues.Type);
        Assert.AreEqual(new List<string> { "First1", "Second1" }, actual.PossibleValues!.Values);
    }

    private class ModelContainingAFieldWithFixedPossibleValues
    {
        [PossibleValuesFromConstant(typeof(SomeIntegerValues))]
        public string WithPossibleValuesAsInteger { get; set; }

        [PossibleValuesFromConstant(typeof(SomeFloatValues))]
        public string WithPossibleValuesAsFloat { get; set; }

        [PossibleValuesFromConstant(typeof(SomeStringValues))]
        public string WithPossibleValuesAsString { get; set; }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        private enum SomeStringValues
        {
            [System.ComponentModel.Description("First1")]
            FirstOne,

            [System.ComponentModel.Description("Second1")]
            SecondOne,
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
        private enum SomeIntegerValues
        {
            [System.ComponentModel.Description("21")]
            FirstOne,

            [System.ComponentModel.Description("42")]
            SecondOne,
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.Float)]
        private enum SomeFloatValues
        {
            [System.ComponentModel.Description("3.14")]
            FirstOne,
        }
    }
}